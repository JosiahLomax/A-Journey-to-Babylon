using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField] TMP_Text MainQuestText;
    [SerializeField] List<TMP_Text> SubQuestObjects;
    void Start()
    {
        SetQuest("Become epic murderer", new List<string> {"murder 10 kids", "Murder 5 dogs", "murder 1 rock"});
    }
    
    public void SetQuest(string MainQuest, List<string> SubQuest)
    {
        MainQuestText.text = "MainQuest: " + MainQuest;
        
        //reminder to fix up this code to allow for more subquest
        for(int I = 0; I < SubQuestObjects.Count; I++)
        {
            SubQuestObjects[I].text = ""; 

            if(I > SubQuestObjects.Count - 1) continue;
            if(I > SubQuest.Count - 1) continue;
            
            SubQuestObjects[I].text = "-"+SubQuest[I];
        }
    }
}
