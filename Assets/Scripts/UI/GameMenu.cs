using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public GameObject inventoryUI;  // The entire UI
    public GameObject menuUI;
    public GameObject FPSDisplay;

    public bool isInventoryActive;
    public bool isMenuActive;

    // Start is called before the first frame update
    void Start()
    {
        isMenuActive = menuUI.activeSelf;
        isInventoryActive = inventoryUI.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if we should open/close the inventory

        if (inventoryUI.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryUI.SetActive(false);
            return;
        }

        if (menuUI.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            menuUI.SetActive(false);
        }
        else if (menuUI.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
            menuUI.SetActive(true);
        }

        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        isMenuActive = menuUI.activeSelf;
        isInventoryActive = inventoryUI.activeSelf;
    }

    public void ShowFPSButton()
    {
        FPSDisplay.SetActive(Main.IsFPSShow);
    }

    public void Leave()
    {
        SceneManager.LoadScene(0);
        PhotonNetwork.LeaveRoom();
    }

}
