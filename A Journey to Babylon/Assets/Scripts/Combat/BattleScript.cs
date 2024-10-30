using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    [Header("Important")]
    BattleDetails Battle;
    [SerializeField] GameObject AlliesContainer;
    [SerializeField] GameObject EnemiesContainer;

    [Header("External Settings")]
    [SerializeField] float ContainerSize;

    [Header("Battle Settings")]
    public GameObject Player;
    public List<MobsInformation> Allies;
    public List<MobsInformation> Enemies;

    public void Start()
    {
        GameObject Sys = GameObject.Find("SystemLoader");
        Battle = Sys.GetComponent<BattleDetails>();
        Allies = Battle.Allies;
        Enemies = Battle.Enemies;

        CreateStack(Allies, AlliesContainer);
        AddPlayer();
        CreateStack(Enemies, EnemiesContainer);
    }
    void CreateStack(List<MobsInformation> x, GameObject Container)
    {
        if(x.Count <= 0) return;
        float AddContain = ContainerSize/x.Count;
        Vector3 ModifiedPosition = Container.transform.position;

        for(int I = 0; I < x.Count; I++)
        {
            if(x[I] == null) return;
            GameObject CurrentObject = Instantiate(x[I].Appearence, ModifiedPosition, transform.rotation, Container.transform);

            ModifiedPosition.y += AddContain; 
            Debug.Log("Spawned Allies");
        }
        
        ModifiedPosition = Container.transform.position;
        ModifiedPosition.y -= ContainerSize - AddContain; 
        Container.transform.position = ModifiedPosition;
    }
    //Add Player has a weird roundable logic but I don't think you can edit scriptable objects during runtime
    //I don't think I'm even suppose to make a allied system
    //but like EVERY single JRPG has one
    //so might as wlel do it
    //So this'll have to do
    void AddPlayer()
    {
        Vector3 ModifiedPosition = AlliesContainer.transform.position;
        ModifiedPosition.y += ContainerSize;
        Instantiate(Player, ModifiedPosition, transform.rotation, AlliesContainer.transform);


        float AddContain = ContainerSize/Allies.Count;
        ModifiedPosition = AlliesContainer.transform.position;
        ModifiedPosition.y -= AddContain; 
        AlliesContainer.transform.position = ModifiedPosition;

    }
}
