using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerRaycasting : MonoBehaviour
{

    public float distanceToSee = 3f;
    RaycastHit hit;
    public GameObject player;
    public Text interactibleName;
    public Camera cam;

    PhotonView PV;

    void Awake()
    {
        PV = GetComponentInParent<PhotonView>();
    }


    void Update()
    {
        if (!PV.IsMine)
            return;

        Debug.DrawRay(cam.transform.position, cam.transform.forward * distanceToSee, Color.magenta);


        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanceToSee))
        {
            GameObject item = hit.collider.gameObject;
            if (item.tag == "Item")
            {
                interactibleName.text = item.name;
                if (Input.GetKey(KeyCode.E))
                {
                    item.GetComponent<ItemPickup>().PickUp();
                }
            }
            else if (item.tag == "Interactible")
            {
                interactibleName.text = item.name;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (item.GetComponent<Interactive>() == true)
                    {
                        item.GetComponent<Interactive>().Interactact(player);
                    }

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




