using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerDetection : MonoBehaviour
{
    //I think it's better to not use unity's event system form this
    //but that might've been a mistake
    SceneLoader SceneChanger;
    [Header("Req Scripts")]
    [SerializeField] Typewriter typewriter;
    [SerializeField] PopupManager Popups;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] GiveItems ItemsGive;

    [Header("Info")]
    [SerializeField] bool NearNpc;
    [SerializeField] Collider2D DetectedCollider;

    void Start()
    {
        //I mean I could just reference it but it might cause some issues when reloading
        //so instead i used a find function please forgive me
        GameObject SceneObject = GameObject.Find("SystemLoader");
        SceneChanger = SceneObject.GetComponent<SceneLoader>(); 
    }

    void Update()
    {
        //weird way but I thijnk it's the best way
        //also this is for the dialog
        if(NearNpc && InputSystem.actions.FindAction("Interact").ReadValue<float>() > 0)
        {
            DialogInfo Info = DetectedCollider.gameObject.GetComponent<DialogInfo>();
            typewriter.StartTalking(Info);

            AddItemsInfo? Info1 = DetectedCollider.gameObject.GetComponent<AddItemsInfo>();
            if(Info1 != null) ItemsGive.AddItem(Info1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        string tag = other.tag;
        DetectedCollider = null;

        switch(tag)
        {
            case "NPC":
            {
                NearNpc = false;
                break;
            }

           default:
                Debug.Log("unable to find tag");
                break; 
        }
 
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //this was not a swithcstatement before
        //because I didn't realize you can change the scope
        //and I want them to have the same name
        //but now I do :D
        if(SceneChanger == null) 
        {
            return;
        }

        string tag = other.tag;
        DetectedCollider = other;

        switch(tag)
        {
            case "BattleSpawn":
            {
                BattleDetails Info = other.gameObject.GetComponent<BattleDetails>();
                SceneChanger.StoredBattle(Info);

                SceneChanger.LoadScene(2);
                break;
            }

            case "NPC":
            {
                NearNpc = true;
                break;
            }

            case "Popup":
            {
                PopupInfo Info = other.gameObject.GetComponent<PopupInfo>();
                Popups.DisplayName(Info);
                break;
            }

            case "Region":
            {
                AudioSource Info = other.gameObject.GetComponent<AudioSource>();
                AudioManager.PlayMusic(Info);
                break;
            }

            default:
                Debug.Log("unable to find tag");
                break;
        }
    }
}
