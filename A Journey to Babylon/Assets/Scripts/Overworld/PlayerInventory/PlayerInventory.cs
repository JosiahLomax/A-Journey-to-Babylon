using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<InventoryEntry> Inventory;
}

[System.Serializable]
public class InventoryEntry
{
    public InventoryEntry(ItemsInformation Items)
    {
        Item_ = Items;
        Quantity = 1;
    }
    public ItemsInformation Item_;
    public int Quantity;
}