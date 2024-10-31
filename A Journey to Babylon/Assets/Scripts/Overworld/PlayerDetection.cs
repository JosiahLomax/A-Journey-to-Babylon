using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    SceneLoader SceneChanger;
    [SerializeField] Typewriter typewriter;
    void Start()
    {
        //I mean I could just reference it but it might cause some issues when reloading
        //so instead i used a find function please forgive me
        GameObject SceneObject = GameObject.Find("SystemLoader");
        SceneChanger = SceneObject.GetComponent<SceneLoader>(); 
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(SceneChanger != null)
        {
            if (other.CompareTag("BattleSpawn"))
            {
                BattleDetails DetailsOfBattle = other.gameObject.GetComponent<BattleDetails>();
                SceneChanger.StoredBattle(DetailsOfBattle);

                SceneChanger.LoadScene(2);
            }
            if (other.CompareTag("NPC"))
            {
                DialogInfo Dialog = other.gameObject.GetComponent<DialogInfo>();
                typewriter.StartTalking(Dialog);

            }
        }
    }
}
