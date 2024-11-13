using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Typewriter : MonoBehaviour
{
    [Header("Important")]

	[SerializeField] Animator Parent;
	[SerializeField] TMP_Text _tmpProText;
    [SerializeField] Image Face;
    [SerializeField] AudioManager Audio;

    // below are the uhhh necessary stuff
	DialogInfo _text;
	string Writer;
    string CurrentWrite;
    int CurrentDialog;
    public bool AlreadyTalking;
    [Header("Settings")]
	[SerializeField] float timeBtwChars = 0.1f;
	[SerializeField] float timeBtwDialogs = 2f;

    public void StartTalking(DialogInfo SentDialog)
    {
        if(AlreadyTalking) return;

        AlreadyTalking = true;
        _text = SentDialog;

        CurrentDialog = 0;
        CurrentWrite = _text.Dialog[CurrentDialog].Words;
        Parent.SetBool("Appear", true);
        StartCoroutine("DisplayText");
    }

    IEnumerator DisplayText()
    {
        AudioClip TalkAudio;
        Face.sprite = _text.Dialog[CurrentDialog]?.Reactions;
        TalkAudio = _text.Dialog[CurrentDialog]?.TalkNoise;

        if(TalkAudio != null)Audio.PlayAudio(TalkAudio);

        Writer = "";
        _tmpProText.text = "";
        for(int I = 0; I < CurrentWrite.Length; I++)
        {
            Writer += _text.Dialog[CurrentDialog].Words[I];
            yield return new WaitForSeconds(timeBtwChars);
            _tmpProText.text = Writer;
        }

        StartCoroutine("TimeAfterText");
    }
    IEnumerator TimeAfterText()
    {
        yield return new WaitForSeconds(timeBtwDialogs);
        CurrentDialog++;
        if(CurrentDialog < _text.Dialog.Count)
        {
            CurrentWrite = _text.Dialog[CurrentDialog].Words;
            StartCoroutine("DisplayText");
        }
        else
        {
            AlreadyTalking = false;
            Parent.SetBool("Appear", false);
        }
    }
}
