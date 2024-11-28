using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{
    //I think it's better to not use unity's event system form this
    //but that might've been a mistake
    SceneLoader SceneChanger;
    [SerializeField] Typewriter typewriter;
    [SerializeField] PopupManager Popups;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] GiveItems ItemsGive;

    void Start()
    {
        //I mean I could just reference it but it might cause some issues when reloading
        //so instead i used a find function please forgive me
        GameObject SceneObject = GameObject.Find("SystemLoader");
        SceneChanger = SceneObject.GetComponent<SceneLoader>(); 
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
                DialogInfo Info = other.gameObject.GetComponent<DialogInfo>();
                typewriter.StartTalking(Info);

                AddItemsInfo? Info1 = other.gameObject.GetComponent<AddItemsInfo>();
                if(Info1 != null) ItemsGive.AddItem(Info1);
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
