using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicSet", menuName = "ScriptableObjects/MusicSet", order = 1)]
public class MusicSetScriptableObject : ScriptableObject
{

    [SerializeField]
    private AudioClip menuMusicClip;

    [SerializeField]
    private AudioClip levelMusicClip;

    public void PlayMenuMusic(AudioSource audioSource)
    {
        PlayMusicClip(audioSource, menuMusicClip);
    }

    public void PlayLevelMusic(AudioSource audioSource)
    {

        PlayMusicClip(audioSource, levelMusicClip);
    }

    public void PlayMusicClip(AudioSource audioSource, AudioClip audioClip)
    {
        if (audioSource.clip != audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }  
    }
}
