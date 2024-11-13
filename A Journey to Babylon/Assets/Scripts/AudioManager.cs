using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource AudioPlayer;

    public void PlayAudio(AudioClip Audio)
    {
        AudioPlayer.clip = Audio;
        AudioPlayer.Play(); 
    }

    public void PlayMusic()
    {

    }
}
