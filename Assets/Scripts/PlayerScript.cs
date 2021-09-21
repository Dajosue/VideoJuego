using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float runSpeed = 5f;
    public float turnSpeed = 2f;

    private float x, y;

    public Rigidbody rb;
    public float jumpHeight = 0.2f;

    // COMPROBAMOS SI HAY SUELO
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    private bool isGrounded;

    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Translate(x * Time.deltaTime * runSpeed, 0 , 0);
        transform.Translate(0, 0, y * Time.deltaTime * turnSpeed);

        // Salto
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKey("space") && isGrounded)
        {

            Invoke("Jump", 0.2f);

        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }


}
