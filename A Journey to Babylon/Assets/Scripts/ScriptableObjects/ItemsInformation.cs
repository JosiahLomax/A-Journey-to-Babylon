using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "BattleInformation/Items", order = 0)]
public class ItemsInformation : ScriptableObject
{
    [Header("Important stuff")]
    public GameObject Appearence;

    [Header("Stats")]
    public string FlavorText;
}
