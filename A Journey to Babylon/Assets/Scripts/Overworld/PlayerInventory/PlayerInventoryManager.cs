using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventoryManager : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] GameObject ItemContainer;
    [SerializeField] Transform ItemParents;
    [SerializeField] int TotalCollums;
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
        Vector3 AddedPosition = new Vector3();

        for(int I = 0; I < inv.Inventory.Count; I++)
        {
            GameObject CreatedItem = Instantiate(ItemContainer, ItemParents);
            CreatedItem.name = "ItemContainer " + I;

            Vector3 CreatedPosition = CreatedItem.transform.position;
            if(I % TotalCollums != 0)
            {
                AddedPosition.x += Padding.x;
            }
            else if(I != 0)
            {
                AddedPosition.y -= Padding.y;
                AddedPosition.x = 0;
            }

            CreatedItem.transform.position = CreatedPosition + AddedPosition; 
        }
    }
}
