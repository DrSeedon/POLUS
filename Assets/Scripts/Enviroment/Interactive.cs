using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mechanism))]
public class Interactive : MonoBehaviour
{
    //Request
    Inventory inventory;
    public Item requestedItem;
    public bool dontRequestItem = false;
    public bool requestManyItem = false;
    public int requestedItems = 1;
    public bool removeItemAfterUse = false;


    public Mechanism mech;



    void Start()
    {
        mech = GetComponent<Mechanism>();
    }

    void Update()
    {
        inventory = Inventory.instance;
    }

    public void Interactact()
    {
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
                        Debug.Log("Недостаточно " + (requestedItems - i) + " предмета " + requestedItem.name);
                        return;
                    }
                }
                Trigger();
            }
            else
            {
                Debug.Log("Недостаточно " + requestedItems + " предмета " + requestedItem.name);
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
                Debug.Log("Недостаточно предмета " + requestedItem.name);
            }
        }


    }

    void RemoveItem()
    {
        if (removeItemAfterUse)
        {
            Debug.Log(requestedItem.name + " удален");
            inventory.Remove(requestedItem);
        }
    }

    void Trigger()
    {
        mech.GetComponent<Mechanism>().enabled = true;
        mech.Trigger();       
    }

}
