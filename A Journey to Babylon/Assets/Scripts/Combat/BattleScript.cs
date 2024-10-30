using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    [Header("Important")]
    [SerializeField] GameObject AlliesContainer;
    [SerializeField] GameObject EnemyContainer;

    [Header("Battle Settings")]
    public List<MobsInformation> Allies = new List<MobsInformation>();
    public List<MobsInformation> Enemies = new List<MobsInformation>();

    public void StartBattle()
    {
        for(int I = 0; I < Allies.Count; I++)
        {
        }
    }
}
