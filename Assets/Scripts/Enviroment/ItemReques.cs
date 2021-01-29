using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReques : MonoBehaviour
{
    public Item requestedItem;
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestItem()
    {
        if (inventory.items.Contains(requestedItem))
        {
            Destroy(this.gameObject);
        }
    }
}
