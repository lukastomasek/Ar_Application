using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] float loadingTimer;
    [SerializeField] GameObject loadingCanvas;
    [SerializeField] Image loadingBar;

    float _timer = 0f;
    AudioSource[] _audios;

    private void Start()
    {
        _audios = FindObjectsOfType<AudioSource>();

        StartCoroutine(InitialLoading());
    }

    public void LoadLevelASync(int lvl)
    {
        StartCoroutine(StartLoading(lvl));
    }

    IEnumerator InitialLoading()
    {
        loadingCanvas.SetActive(true);

        if (_audios.Length != 0)
        {
            foreach (var a in _audios)
                a.mute = true;
        }

        Debug.Log("loading");
        while (_timer < 1)
        {
            _timer += Time.deltaTime * loadingTimer;

            loadingBar.fillAmount = _timer;
            yield return null;

            if (_timer > 1)
            {
                if (_audios.Length != 0)
                    foreach (var a in _audios)
                        a.mute = false;

                loadingCanvas.SetActive(false);
            }
        }

    }



    IEnumerator StartLoading(int scene)
    {
        if (loadingTimer == 0)
            loadingTimer = 0.5f;


        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);

        if (ao == null)
            Debug.LogError($"missing scene : {scene} ");

        loadingCanvas.SetActive(true);

        while (!ao.isDone)
        {
            float timer = ao.progress / 0.9f;

            loadingBar.fillAmount = timer;

            yield return null;
        }


    }
}
