using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public static SoundManger soundIndtance;

    public AudioSource audioSource,moveAudioSource,jumpAudioSource,DashAudioSource,AttackAudioSource;
    public AudioClip move,jump, rum, hurt, die,dash,attack,openDoor, closeDoor;

    private void Awake()
    {
        soundIndtance = this;
    }
    public void IdleAudio()
    {
        moveAudioSource.clip = null;
        moveAudioSource.Play();
    }

    public void MoveAudio()
    {
        moveAudioSource.clip = move;
        moveAudioSource.Play();
    }
    public void JumpAudio()
    {
        jumpAudioSource.clip = jump;
        jumpAudioSource.Play();

    }

    public void DashAudio()
    {
        DashAudioSource.clip = dash;
        DashAudioSource.Play();
    }
    
    public void AttackAudio()
    {
        AttackAudioSource.clip = attack;
        AttackAudioSource.Play();
    }

    public void OpenDoorAudio()
    {
        audioSource.clip = openDoor;
        audioSource.Play();
    }

    public void CloseDoorAudio()
    {
        audioSource.clip = closeDoor;
        audioSource.Play();
    }
}
