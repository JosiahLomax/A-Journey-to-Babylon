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
        //I prob could have done this in a better way...
        //but like it works and it's pretty darn readable
        //actualy this is prob the best way to do it

        if(SceneChanger != null) 
        {
            if (other.CompareTag("BattleSpawn"))
            {
                BattleDetails Info = other.gameObject.GetComponent<BattleDetails>();
                SceneChanger.StoredBattle(Info);

                SceneChanger.LoadScene(2);
            }

            if (other.CompareTag("NPC"))
            {
                DialogInfo Info = other.gameObject.GetComponent<DialogInfo>();
                typewriter.StartTalking(Info);

                AddItemsInfo? Info1 = other.gameObject.GetComponent<AddItemsInfo>();
                if(Info1 != null) ItemsGive.AddItem(Info1);

            }

            if (other.CompareTag("Popup"))
            {
                PopupInfo Info = other.gameObject.GetComponent<PopupInfo>();
                Popups.DisplayName(Info);

            }

            if (other.CompareTag("Region"))
            {
                AudioSource Info = other.gameObject.GetComponent<AudioSource>();
                AudioManager.PlayMusic(Info);

            }
        }
    }
}
