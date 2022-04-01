using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    float xRot = 0;
    public float sensitivity = 100;
    public Transform player;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
       float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
    }
}
