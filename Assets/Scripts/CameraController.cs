using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 800f;

    public Transform playerBody;

    float mouseX;
    float mouseY;

    float xRotation = 0;

    // Start is called before the first frame update
    void Start()
    {

        // El ratón se esconde
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        // PARA QUE TENGA UN MÁXIMO 
        xRotation = Mathf.Clamp(xRotation, -5f, 30f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

    }
}
