using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItems : MonoBehaviour
{
    [SerializeField] PlayerInventory Inv;
    [SerializeField] PlayerInventoryManager InvManage;
    public void AddItem(ItemsInformation Item)
    {
        bool ContainedIn = false;
        for(int I = 0; I < Inv.Inventory.Count; I++)
        {
            if(Inv.Inventory[I].Item_ == Item)
            {
                ContainedIn = true;
                Inv.Inventory[I].Quantity++;
            }
        }

        if(!ContainedIn)
        {
            InventoryEntry newItem = new InventoryEntry(Item);
        }
    }
}
