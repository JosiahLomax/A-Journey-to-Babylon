using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItems : MonoBehaviour
{
    [SerializeField] PlayerInventory Inv;
    [SerializeField] PlayerInventoryManager InvManage;
    public void AddItem(AddItemsInfo Item)
    {
        bool ContainedIn = false;
        for(int I = 0; I < Inv.Inventory.Count; I++)
        {
            if(Inv.Inventory[I].Item_ == Item.Item)
            {
                ContainedIn = true;
                Inv.Inventory[I].Quantity += Item.Quantity;
            }
        }

        if(!ContainedIn)
        {
            InventoryEntry newItem = new InventoryEntry(Item.Item);
        }

        InvManage.UpdateInv();
    }
}
