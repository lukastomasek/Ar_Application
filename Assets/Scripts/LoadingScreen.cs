using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] float loadingTimer;
    [SerializeField] bool useAsync = false;
    [SerializeField] GameObject parent;
    [SerializeField] Image loadingBar;
    [SerializeField] int scene;
    float _timer = 0f;
    AudioSource[] _audios;

    private void Start()
    {
        _audios = FindObjectsOfType<AudioSource>();

        StartCoroutine(StartLoading());
    }


    IEnumerator StartLoading()
    {
        if (loadingTimer == 0)
            loadingTimer = 0.5f;

        if (useAsync)
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync(scene);

            if (ao == null)
                Debug.LogError($"missing scene : {scene} ");

            while (!ao.isDone)
            {
                float timer = ao.progress / 0.9f;

                loadingBar.fillAmount = timer;

                yield return null;
            }
        }
        else
        {
            parent.SetActive(true);

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

                    gameObject.SetActive(false);
                }
            }
        }
    }
}
