using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "PlayerStuff", order = 1)]
public class Item : ScriptableObject
{
    public Sprite Appearence;
    public string Name;
}
