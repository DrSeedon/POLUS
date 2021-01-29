using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycasting : MonoBehaviour
{

    public float distanceToSee = 3f;
    RaycastHit hit;
    public GameObject player;
    public Text interactibleName;

    void Start()
    {

    }

    void Update()
    {

        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);


        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            GameObject item = hit.collider.gameObject;
            if (item.tag == "Item")
            {
                interactibleName.text = item.name;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    item.GetComponent<ItemPickup>().PickUp();
                }
            }
            else if (item.tag == "Interactible")
            {
                interactibleName.text = item.name;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    item.GetComponent<ItemReques>().RequestItem();
                }                
            }
            else
            {
                interactibleName.text = "";
            }
        }
        else
        {
            interactibleName.text = "";
        }
    }



}
