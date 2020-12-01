using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    [SerializeField] LoadingScreen loadingScreen;

    private void Awake()
    {
        if (loadingScreen == null)
            loadingScreen = FindObjectOfType<LoadingScreen>();
    }

    public void Play()
    {
        loadingScreen.LoadLevelASync(1);
    }
}
