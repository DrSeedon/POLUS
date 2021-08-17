using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemInfo itemInfo;
    public GameObject itemGameObject;
    public bool isActive = false;

    public abstract void Use();

    public void ActiveHand(bool active)
    {
        isActive = active;
        itemGameObject.SetActive(active);
    }

}
