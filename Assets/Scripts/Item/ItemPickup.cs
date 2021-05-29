using UnityEngine;

public class ItemPickup : MonoBehaviour
{

	public ItemInfo item;	// Item to put in the inventory on pickup

	
	// Pick up the item
	public void PickUp ()
	{
		Debug.Log("�������� " + item.name);
		bool wasPickedUp = Inventory.instance.Add(item);	// Add to inventory

		// If successfully picked up
		if (wasPickedUp)
			Destroy(gameObject);	// Destroy item from scene
	}

}
