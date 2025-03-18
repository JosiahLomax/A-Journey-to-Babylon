using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource AudioPlayer;
    [SerializeField] AudioSource MusicPlayer;
    //LIKE i'm not sure to put this in either the player scirpt or this audio script
    // i'll but it here please tell me to change it if so ;-;
    [Header("Player Audio Clips")]
    [SerializeField] AudioClip Walk;
    [SerializeField] AudioClip Slice;

    //I'm not sure how yall want this, so i'll just put this in for now
    InputAction moveAction;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    public void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue.x != 0 || moveValue.y != 0) 
        {
            if (AudioPlayer.isPlaying) return;
            PlayAudio(Walk);
        }
        else
        {
            AudioPlayer.Stop();
        }
    }

    //a little cheap hack >:D
    public void PlaySlice()
    {
        AudioPlayer.clip = Slice;
        AudioPlayer.Play(); 
    }

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
