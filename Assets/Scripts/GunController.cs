using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{

    public int damage;
    public float timeBtwShooting, reloadTime, range, spread, timeBtwShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShots;

    // Booleans

    bool shooting, readyToShot, reloading;

    // References

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatsIsEnemy;

    // Graphics 

    public TextMeshProUGUI text;
    
    public GameObject muzzleFlash, bulletHoleGraphic;
    // public CamShake camShake;




    private void Awake()
    {

        bulletsLeft = magazineSize;
        readyToShot = true;


    }

    private void Update()
    {

        MyInput();

    }
    private void MyInput()
    {

        ///// RÁFAGAS /////

        // SI PUEDE MANTENER EL BOTON DISPARARÁ MIENTRAS ESTÉ EL BOTON CLICK
        if (allowButtonHold)
        {
            
            shooting = Input.GetKey(KeyCode.Mouse0);

        }
        else
        {

            // SI NO, SOLO CUANDO EL RATÓN SE CLICKE
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        }


        ///// RECARGA /////
        
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {

            Reload();

        }

        ///// DISPARO /////

        if(readyToShot && shooting && !reloading && bulletsLeft > 0)
        {

            bulletsShots = bulletsPerTap;
            Shoot();

        }

    }


    private void Reload()
    {

        reloading = true;
        Invoke("ReloadFinished", reloadTime);

    }private void ReloadFinished()
    {

        bulletsLeft = magazineSize;
        reloading = false;

    }

    private void Shoot()
    {

        readyToShot = false;

        // Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // Calculate the new direction with the spread 
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        // RAYCAST PARA EL DISPARO
        if(Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatsIsEnemy))
        {

            Debug.Log(rayHit.collider.name);
            if (rayHit.collider.CompareTag("Enemy"))
            {

                //rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);

            }

        }

        // Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0)); 
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity); 


        bulletsLeft--;
        bulletsShots--;
        //PERMITE INVOCAR UNA FUNCION CON X TIEMPO DE DELAY
        Invoke("ResetShoot", timeBtwShooting);

        if(bulletsShots > 0 && bulletsLeft > 0)
        {

            Invoke("Shoot", timeBtwShooting);

        }

    }

    private void ResetShoot()
    {
        
        readyToShot = true;

    }

}
