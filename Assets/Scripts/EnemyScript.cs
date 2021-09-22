using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int hp;

    private void Update()
    {

        if (Input.GetMouseButton(0))
            Destroy();

    }


    private void Destroy()
    {

        gameObject.SetActive(false);
    }




}
