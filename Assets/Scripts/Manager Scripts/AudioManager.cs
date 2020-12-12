using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   

    [Header("Audio Sources")]
    [SerializeField] AudioSource bgAudio;
    [SerializeField] AudioSource btnAudio;
    [Space]
    [Header("Audio Clips")]
    [SerializeField] AudioClip btnClick;


    public void ButtonSound()
    {
        btnAudio.PlayOneShot(btnClick);
    }

}
