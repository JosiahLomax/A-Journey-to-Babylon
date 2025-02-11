using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogFinished : MonoBehaviour
{
    //this is for giving items after the dialog finishes
    //usually i'll make a unity event for this in the dialog script
    //but I don't want to touch their script so this is a roundabout way
    //ahhh it might be bad performance wise because of it 
    //but that's a problem for next time.
    [SerializeField] UnityEvent FinishedDialog;
    [SerializeField] NPC1 NpcScript;
    void Update()
    {
        //fuckkk i'll have to touch it to see the index. ahhhhh it's fine
        if(NpcScript.dialogue.Length - 1 == NpcScript.index)
        {
            FinishedDialog.Invoke();
        }
    }
}
