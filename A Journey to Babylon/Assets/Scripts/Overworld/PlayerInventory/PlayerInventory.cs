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
    public ItemsInformation Item_;
    public int Quantity;
}