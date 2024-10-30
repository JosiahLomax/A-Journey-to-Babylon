using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mobs", menuName = "BattleInformation/Mobs", order = 0)]
public class MobsInformation : ScriptableObject
{
    [Header("Important stuff")]
    public GameObject Appearence;
    public Animator Animator;

    [Header("Stats")]
    public int MaxHealth;
    public int MagicStones;
    public int AttackDamage;

    [Header("Moves")]
    public List<MagicMoves> Moves;
}
