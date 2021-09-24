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
        gun = FindObjectOfType<GunController>();
        Text textAmmo = GameObject.Find("textGun").GetComponent<Text>();
        bulletSlider.value = gun.magazineSize;
        textAmmo.text = bulletSlider.value + " / " + gun.magazineSize;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    void FixedUpdate() 
    {
        gun = FindObjectOfType<GunController>();
        Text textAmmo = GameObject.Find("textGun").GetComponent<Text>();
        textAmmo.text = gun.bulletsLeft + " / " + gun.magazineSize;
        bulletSlider.value = gun.bulletsLeft;
        if (gun.bulletsLeft==0)
        {
            textAmmo.text = "Pulse R to Reload";
        }
    }
}
