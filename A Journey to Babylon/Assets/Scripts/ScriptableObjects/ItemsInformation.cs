using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Items", menuName = "BattleInformation/Items", order = 0)]
public class ItemsInformation : ScriptableObject
{
    [Header("Important stuff")]
    public Image Appearence;

    [Header("Stats")]
    public string FlavorText;
}
