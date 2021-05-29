using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An Item that can be equipped. */

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : ItemInfo {



	public EquipmentSlot equipSlot;	// Slot to store equipment in

	public int armorModifier;		// Increase/decrease in armor
	public int damageModifier;      // Increase/decrease in damage
    public SkinnedMeshRenderer mesh;
    public EquipmentManager.MeshBlendShape[] coveredMeshRegions;

	// When pressed in inventory
	public override void Use(GameObject player)
	{
		base.Use(player);
		//EquipmentManager.instance.Equip(this);	// Equip it

		RemoveFromInventory();					// Remove it from inventory
	}

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
