using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Magic", menuName = "BattleInformation/Magic", order = 0)]
public class MagicMoves : ScriptableObject
{
    [Header("Important stuff")]
    public GameObject Appearence;

    [Header("Stats")]
    public int MagicStones;
    public int AttackDamage;
}

