using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthSlider;
    
    void Start()
    {
        healthSlider.value = 30;
        Debug.Log(healthSlider.value + " primer valor");
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    void FixedUpdate() 
    {
     if (Input.GetKey("g")) 
        {
            healthSlider.value = ((float)(healthSlider.value - 1));
            Debug.Log(healthSlider.value + " valor actual");
        }
    }
}
