using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    [SerializeField] GameObject DisplayHolder;
    [SerializeField] TMP_Text LocationNameText;
    PopupInfo CurrentInfo;
    bool AlreadyStartedDisplay;
    void Start()
    {
        DisplayHolder.SetActive(false);
    }

    public void DisplayName(PopupInfo Info)
    {
        if(AlreadyStartedDisplay) return;
        AlreadyStartedDisplay = true;

        CurrentInfo = Info;

        LocationNameText.text = CurrentInfo.Name;
        DisplayHolder.SetActive(true);

        StartCoroutine(DurationOfDisplay());
    }
    IEnumerator DurationOfDisplay()
    {
        yield return new WaitForSeconds(CurrentInfo.Duration);

        DisplayHolder.SetActive(false);
        AlreadyStartedDisplay = false;
    }
}
