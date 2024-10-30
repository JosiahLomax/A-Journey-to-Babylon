using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] BattleScript FightManager;
    public void PlayerAttack()
    {
        BattleLayer Attack = new BattleLayer();
        Attack.Type = "Attack";
        Attack.ID = "";
        Attack.PersonAffected = new Vector2Int(1, 0);
        Attack.PersonCasting = new Vector2Int(0, 0);
        FightManager.AddAction(Attack);
        FightManager.EndTurn();
    }
    /*
    public void PlayerMagic()
    {
        BattleLayer Attack = new BattleLayer();
        Attack.Type = "Attack";
        Attack.ID = "";
        Attack.PersonAffected = new Vector2(1, 0);
        Attack.PersonCasting = new Vector2(0, 0);
        FightManager.AddAction(Attack);
        FightManager.EndTurn();
    }
    */
    public void PlayerDefend()
    {
        BattleLayer Defend = new BattleLayer();
        Defend.Type = "Defend";
        Defend.ID = "";
        Defend.PersonAffected = new Vector2Int(0, 0);
        Defend.PersonCasting = new Vector2Int(0, 0);
        FightManager.AddAction(Defend);
        FightManager.EndTurn();
    }
}
