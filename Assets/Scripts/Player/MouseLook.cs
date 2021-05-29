using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public float mouseSensitivityNormal = 100f;
    public float mouseSensitivityZoomed = 30f;

    public Transform playerBody;

    float xRotation = 0f;

    public GameMenu Menu;

    public Camera cam;
    public float FOVStandart = 60f;
    public float FOVZoomed = 20f;
    public float speedZoomIn = 5f;
    public float speedZoomOut = 10f;

    PhotonView PV;

    void Awake()
    {
        PV = GetComponentInParent<PhotonView>();
    }

    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!PV.IsMine)
            return;
        ChangeFOV();
        if (Menu.isInventoryActive)
        {
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        else if (Menu.isMenuActive)
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

        this.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void ChangeFOV()
    {
        if (Input.GetButton("Fire2"))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, FOVZoomed, Time.deltaTime * speedZoomIn);
            mouseSensitivity = mouseSensitivityZoomed;
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, FOVStandart, Time.deltaTime * speedZoomOut);
            mouseSensitivity = mouseSensitivityNormal;
        }
    }
}
