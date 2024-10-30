using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAttack : MonoBehaviour
{
    List<Stats> Enemies;
    [SerializeField] BattleScript FightManager;
    public void EnemiesAction()
    {
        //for(int I = 0; I < Enemies.Count; I++)
        //{
        EnemyAttack();
        //}
    }

    void EnemyAttack()
    {
        BattleLayer Attack = new BattleLayer();
        Attack.Type = "Attack";
        Attack.ID = "";
        Attack.PersonAffected = new Vector2Int(0, 0);
        Attack.PersonCasting = new Vector2Int(1, 0);
        FightManager.AddAction(Attack);
    }
}
