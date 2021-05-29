using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemInfo : ScriptableObject
{

    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    // Called when the ItemInfo is pressed in the inventory
    public virtual void Use(GameObject player)
    {
        // Use the ItemInfo
        // Something might happen 
        if (itemName == "Ammo Box")
        {
            player.GetComponent<Stats>().ammo += 100;
            player.GetComponent<Stats>().UpdateStats();
            Inventory.instance.Remove(this);
        }
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}
