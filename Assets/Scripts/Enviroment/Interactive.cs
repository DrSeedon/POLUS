using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mechanism))]
public class Interactive : MonoBehaviour
{
    //Request
    Inventory inventory;
    public ItemInfo requestedItem;
    public bool dontRequestItem = false;
    public bool requestManyItem = false;
    public int requestedItems = 1;
    public bool removeItemAfterUse = false;

    public bool isGiveItem = false;
    public ItemInfo givenItem;

    GameObject player;

    public Mechanism mech;



    void Start()
    {
        mech = GetComponent<Mechanism>();
    }

    void Update()
    {
        inventory = Inventory.instance;
    }

    public void Interactact(GameObject p)
    {
        player = p;
        if (dontRequestItem)
        {
            Trigger();
            return;
        }

        if (requestManyItem)
        {
            if (inventory.items.Contains(requestedItem))
            {
                for (int i = 0; i < requestedItems; i++)
                {
                    if (inventory.items.Contains(requestedItem))
                    {
                        RemoveItem();
                    }
                    else
                    {
                        for (int n = 0; n < i; n++)
                        {
                            inventory.Add(requestedItem);
                        }
                        Debug.Log("������������ " + (requestedItems - i) + " �������� " + requestedItem.name);
                        return;
                    }
                }
                Trigger();
            }
            else
            {
                Debug.Log("������������ " + requestedItems + " �������� " + requestedItem.name);
            }

        }
        else
        {
            if (inventory.items.Contains(requestedItem))
            {
                RemoveItem();
                Trigger();
            }
            else
            {
                Debug.Log("������������ �������� " + requestedItem.name);
            }
        }


    }

    void RemoveItem()
    {
        if (removeItemAfterUse)
        {
            Debug.Log(requestedItem.name + " ������");
            inventory.Remove(requestedItem);
        }
    }

    void Trigger()
    {
        if (isGiveItem)
        {
            inventory.Add(givenItem);
        }
        mech.GetComponent<Mechanism>().enabled = true;
        mech.Trigger(player);        
    }

}
