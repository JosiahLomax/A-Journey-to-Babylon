using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] GameObject ItemContainer;
    [SerializeField] Transform ItemParents;
    [SerializeField] Vector2 TotalSize;
    [SerializeField] Vector2 Padding;

    [Header("Debug")]
    [SerializeField] GameObject InventoryObject;
    [SerializeField] PlayerInventory inv;

    void Start()
    {
        CreateInv();
    }

    void CreateInv()
    {
        GameObject SystemLoader = GameObject.Find("SystemLoader");
        inv = SystemLoader.GetComponent<PlayerInventory>();

        for(int I = 0; I < inv.Inventory.Count; I++)
        {
            ItemContainer.name = "ItemContainer" + I;
            Instantiate(ItemContainer, ItemParents);
        }
    }
}
