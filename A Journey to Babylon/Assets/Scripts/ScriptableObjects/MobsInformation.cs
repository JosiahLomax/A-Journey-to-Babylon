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
    public int Heath;
    public int AttackDamage;

    [Header("Magic Moves")]
    public List<MagicMoves> Moves;
}

public class MagicMoves
{
    public int MagicStones;
    public int Damage;
}
