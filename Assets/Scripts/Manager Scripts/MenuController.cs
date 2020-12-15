using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuController : MonoBehaviour
{

    public Action<int> onLevelSelected;

    [SerializeField] LoadingScreen loadingScreen;
    [SerializeField] GameObject levels;

    int _actualLevel;

    private void Awake()
    {
        if (loadingScreen == null)
            loadingScreen = FindObjectOfType<LoadingScreen>();

        levels.SetActive(false);

        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        onLevelSelected += SelectedLevel;
    }

    private void OnDisable()
    {
        onLevelSelected -= SelectedLevel;

    }

    void SelectedLevel(int lvl)
    {
        _actualLevel = lvl;
        Debug.Log($"selected level : {_actualLevel}");
    }

    public void Play()
    {
        if (_actualLevel == 0) _actualLevel = 1;

        loadingScreen.LoadLevelASync(_actualLevel);
    }

    public void OpenLevels() => levels.SetActive(true);

    public void CloseLevels() => levels.SetActive(false);

    public void SelectLevel(int lvl)
    {
        onLevelSelected?.Invoke(lvl);
    }
}
