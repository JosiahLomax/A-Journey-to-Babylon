using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource AudioPlayer;
    [SerializeField] AudioSource MusicPlayer;

    public void PlayAudio(AudioClip Audio)
    {
        AudioPlayer.clip = Audio;
        AudioPlayer.Play(); 
    }

    public void PlayMusic(AudioSource Music)
    {
        if(MusicPlayer.clip == Music.clip)return;

        MusicPlayer.clip = Music.clip;
        MusicPlayer.Play(); 
    }
}
