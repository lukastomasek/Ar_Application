using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LukasScripts;

public class GameplayAudio : MonoBehaviour
{
    public static GameplayAudio instance;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip buttonClick;

    [SerializeField] AudioClip[] fightClips;

    HelperClass _helperClass;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        _helperClass = new HelperClass();

    }

    public void PlayAttackSound()
    {
    //    AudioClip clip = _helperClass.RandomAudio(fightClips);
    //    audioSource.PlayOneShot(clip);
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonClick);
    }
}
