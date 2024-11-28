using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class BattleScript : MonoBehaviour
{
    BattleDetails Battle;
    [SerializeField] GameObject AlliesContainer;
    [SerializeField] GameObject EnemiesContainer;
    [SerializeField] TMP_Text GameState_Text;

    [Header("External Settings")]
    [SerializeField] float ContainerSize;

    [Header("Battle Players")]
    public GameObject Player;
    public List<MobsInformation> Allies;
    public List<MobsInformation> Enemies;

    [Header("Battle Settings")]
    [SerializeField] float AnimationTime;

    [Header("Battle Layout")]
    public List<BattleLayer> BattleQueue;
    [Header("Fight Status")]
    //Gonna make it a vector 2 then index it
    //decided not to do enum and have it as states, but that might hurt me
    [SerializeField] Vector2 CurrentMobTurn;
    [SerializeField] bool CurrentlyPlaying;

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
            CurrentObject.name = x[I].name;

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
    //may the code gods forgive me, this'll have to do
    void AddPlayer()
    {
        Vector3 ModifiedPosition = AlliesContainer.transform.position;
        if(Allies.Count > 0) ModifiedPosition.y += ContainerSize;
        GameObject CurrentPlayer = Instantiate(Player, ModifiedPosition, transform.rotation, AlliesContainer.transform);
        CurrentPlayer.name = "Player";
        
        if(Allies.Count <= 0) return;

        float AddContain = ContainerSize/Allies.Count;
        ModifiedPosition = AlliesContainer.transform.position;
        ModifiedPosition.y -= AddContain; 
        AlliesContainer.transform.position = ModifiedPosition;

    }
    
    //Useable Scripts
    public void AddAction(BattleLayer Layer)
    {
        if(CurrentlyPlaying)
        {
            return;
        }
        BattleQueue.Add(Layer);
    }
    public void EndTurn()
    {
        if(BattleQueue.Count <= 0 || CurrentlyPlaying)
        {
           return; 
        }
        CurrentlyPlaying = true;
        //look for person who casted
        GameObject PersonCast;
        GameObject PersonHit;
        Transform TempPerson;

        for(int I = 0; I < BattleQueue.Count; I++)
        {
            //I know I have a better way of doing this but I am simply 
            //TOO FUCKING RETARDED
            if(BattleQueue[I].PersonCasting[0] == 0)
            {
                TempPerson = AlliesContainer.transform.GetChild(BattleQueue[I].PersonCasting[1]);
                PersonCast = TempPerson.gameObject;
            }
            else
            {
                TempPerson = EnemiesContainer.transform.GetChild(BattleQueue[I].PersonCasting[1]);
                PersonCast = TempPerson.gameObject;
            }

            if(BattleQueue[I].PersonAffected[0] == 0)
            {
                TempPerson = AlliesContainer.transform.GetChild(BattleQueue[I].PersonAffected[1]);
                PersonHit = TempPerson.gameObject;
            }
            else
            {
                TempPerson = EnemiesContainer.transform.GetChild(BattleQueue[I].PersonAffected[1]);
                PersonHit = TempPerson.gameObject;
            }

            Stats CastStat = PersonCast.GetComponent<Stats>();
            Stats HitStat = PersonHit.GetComponent<Stats>();

            StartCoroutine(DelayedAction(PersonCast, PersonHit, CastStat, HitStat, I));
        }
    }
    //so this is a bit of a hack
    //I first use a coroutine to start it
    //make it wait 2-3 seconds for animation
    //then actually start the thing
    //the problem is that i'm passing through like 8 params
    //so I think there's a cleaner way but honestly idc
    IEnumerator DelayedAction(GameObject PersonCast_, GameObject PersonHit_, Stats CastStat_, Stats HitStat_, int Current_)
    {
        //animation
        Animator? CastingAnimator = PersonCast_.GetComponent<Animator>();
        if(CastingAnimator == null) Debug.LogError("No animator on casting gameobject");
        //Todo: update this with like a move index thing to
        //make animation for eveyrhting.
        CastingAnimator.SetTrigger("PlayerHit");

        yield return new WaitForSeconds(AnimationTime);

        //actions after waiting
        TakeAction(PersonCast_, PersonHit_, CastStat_, HitStat_, Current_);
        CurrentlyPlaying = false;
    }
    //dude i'm sorry for programming it like this
    void TakeAction(GameObject PersonCast, GameObject PersonHit, Stats CastStat, Stats HitStat, int Current)
    {
        GameState_Text.text = PersonCast.name + "'s Turn";

        Debug.Log("Dealt:" + CastStat.Attack.ToString());
        if(BattleQueue[Current].Type == "Attack") HitStat.Damage(CastStat.Attack);
        if(BattleQueue[Current].Type == "Defend") Debug.Log("Defend");

        GameState_Text.text = PersonHit.name + "'s Turn";

        BattleQueue.Remove(BattleQueue[Current]);
    }
}



[System.Serializable]
public class BattleLayer
{
    public string Type;
    public string ID;
    public Vector2Int PersonAffected;
    public Vector2Int PersonCasting;
}
