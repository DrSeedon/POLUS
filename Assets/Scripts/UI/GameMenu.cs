using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    public GameObject inventoryUI;  // The entire UI
    public GameObject menuUI;
    public GameObject optionsUI;
    public GameObject FPSDisplay;

    public Button showFPSButton;

    public Color buttonActivateColor;
    public Color buttonDeactivateColor;

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

        if (Input.GetButtonDown("Inventory")) //Button E
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        isMenuActive = menuUI.activeSelf;
        isInventoryActive = inventoryUI.activeSelf;
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
        FPSDisplay.SetActive(!FPSDisplay.activeSelf);
        if (FPSDisplay.activeSelf)
            showFPSButton.GetComponent<Image>().color = buttonActivateColor;        
        else
            showFPSButton.GetComponent<Image>().color = buttonDeactivateColor; 
        
    }
}
