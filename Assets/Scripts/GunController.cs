using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            Shoot();

        }

    }


    private void Reload()
    {

    }

    private void Shoot()
    {

        readyToShot = false;

        // RAYCAST PARA EL DISPARO
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatsIsEnemy))
        {

            Debug.Log(rayHit.collider.name);
            if (rayHit.collider.CompareTag("Enemy"))
            {

                //rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);

            }

        }

        bulletsLeft--;
        //PERMITE INVOCAR UNA FUNCION CON X TIEMPO DE DELAY
        Invoke("ResetShoot", timeBtwShooting);
    }

    private void ResetShoot()
    {

        readyToShot = true;

    }

}
