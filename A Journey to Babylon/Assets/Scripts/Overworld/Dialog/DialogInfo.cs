using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInfo : MonoBehaviour
{
    public List<SpeechLayer> Dialog;
}

[System.Serializable]
public class SpeechLayer
{
    public string Words;
    public Sprite Reactions;
    public AudioClip TalkNoise;
}
