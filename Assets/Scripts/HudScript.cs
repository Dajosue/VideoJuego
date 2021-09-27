using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider bulletSlider;
    private GunController gun;

    


    void Start()
    {
        Text reloadingText = GameObject.Find("reloading").GetComponent<Text>();
        gun = FindObjectOfType<GunController>();
        Text textAmmo = GameObject.Find("textGun").GetComponent<Text>();
        bulletSlider.value = gun.magazineSize;
        textAmmo.text = bulletSlider.value + " / " + gun.magazineSize;

        reloadingText.text = "Reloading...";
        reloadingText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    void FixedUpdate() 
    {
            Text reloadingText = GameObject.Find("reloading").GetComponent<Text>();
            gun = FindObjectOfType<GunController>();

        if (gun.reloading)
        {

            reloadingText.enabled = true;

        }
        else
        {

            reloadingText.enabled = false;
        }

        
        Text textAmmo = GameObject.Find("textGun").GetComponent<Text>();
        textAmmo.text = gun.bulletsLeft + " / " + gun.magazineSize;
        bulletSlider.value = gun.bulletsLeft;
        if (gun.bulletsLeft==0)
        {
            textAmmo.text = "Pulse R to Reload";

        }
    }
}
