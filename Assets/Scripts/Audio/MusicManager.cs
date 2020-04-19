using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public enum MusicType
    {
        Menu,
        Level,
    }

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private MusicSetScriptableObject musicSet;

    [SerializeField]
    private MusicType musicType;

    // Start is called before the first frame update
    void Start()
    {
        switch (musicType)
        {
            case MusicType.Menu:
                musicSet.PlayMenuMusic(audioSource);
                break;
            case MusicType.Level:
                musicSet.PlayLevelMusic(audioSource);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
