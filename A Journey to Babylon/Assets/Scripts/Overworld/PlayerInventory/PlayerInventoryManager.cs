using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] Vector2 Size;
    [SerializeField] Vector2 Padding;

    [Header("Debug")]
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
            
        }
    }
}
