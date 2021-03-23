using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject inventoryUI;  // The entire UI
    public GameObject menuUI;
    public GameObject optionsUI;

    public Color buttonActivateColor;
    public Color buttonDeactivateColor;

    // Start is called before the first frame update
    void Start()
    {

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
    }

    public void ResumeButton()
    {
        menuUI.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void ShowFPSButton()
    {

    }
}
