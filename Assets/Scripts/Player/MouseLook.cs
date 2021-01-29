using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public InventoryUI inventoryUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;        
    }

    void Update()
    {        
        if (inventoryUI.inventoryUI.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
            

        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
