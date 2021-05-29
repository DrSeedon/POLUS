using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour {

	public Image icon;			
	public Button removeButton;

	ItemInfo item;

	Stats player;


	private void Start()
    {
		player = transform.GetComponentInParent<Stats>();
    }

    // Add item to the slot
    public void AddItem (ItemInfo newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	// Clear the slot
	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	// Called when the remove button is pressed
	public void OnRemoveButton ()
	{
		Inventory.instance.Remove(item);
	}

	// Called when the item is pressed
	public void UseItem ()
	{
		if (item != null)
		{
			item.Use(player.gameObject);
		}
	}

}
