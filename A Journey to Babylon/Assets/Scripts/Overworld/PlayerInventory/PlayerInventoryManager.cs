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
    [SerializeField] PlayerInventory inv;


    void Start()
    {
        CreateInv();
    }
    public void UpdateInv()
    {
        DeleteInv();
        CreateInv();
    }
    void DeleteInv()
    {
        for (int I = ItemParents.childCount - 1; I >= 0; I--)
        {
            Destroy(ItemParents.GetChild(I).gameObject);
        }
    }

    void CreateInv()
    {
        GameObject SystemLoader = GameObject.Find("SystemLoader");
        inv = SystemLoader.GetComponent<PlayerInventory>();
        Vector3 AddedPosition = new Vector3();

        for(int I = 0; I < inv.Inventory.Count; I++)
        {
            GameObject CreatedItem = Instantiate(ItemContainer, ItemParents); //Item positions
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


            //Item Appearence
            CreatedItem.transform.position = CreatedPosition + AddedPosition;

            Image ItemImage = CreatedItem?.GetComponent<Image>(); //null check
            if(ItemImage == null) Debug.LogWarning("No image component");

            ItemImage.sprite = inv.Inventory[I].Item_?.Appearence;

            //Text apperance
            TMP_Text AmountOfItemText = CreatedItem.transform.GetChild(0)?.GetComponent<TMP_Text>();
            if(AmountOfItemText == null) Debug.LogWarning("No image component");

            AmountOfItemText.text = inv.Inventory[I].Quantity.ToString();
        }
    }
}
