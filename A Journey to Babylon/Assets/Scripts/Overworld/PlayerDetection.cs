using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    SceneLoader SceneChanger;
    void Start()
    {
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
        }
    }
}
