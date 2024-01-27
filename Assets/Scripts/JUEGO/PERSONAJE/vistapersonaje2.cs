using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vistapersonaje2 : MonoBehaviour
{
    public float mouseSensivity = 80f;

    public Transform playerBody;

    float xRotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -60f, 50f);

        transform.localRotation = Quaternion.Euler(xRotation, 180, 0);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
