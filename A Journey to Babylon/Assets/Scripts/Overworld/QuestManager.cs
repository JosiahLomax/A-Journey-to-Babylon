using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField] string MainQuest;
    [SerializeField] List<string> SubQuest;

    [Header("Quest System Req")]
    [SerializeField] TMP_Text MainQuestText;
    [SerializeField] List<TMP_Text> SubQuestText;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
