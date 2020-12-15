using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScaleUI : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    Ease easeMode;

    Vector3 _originalScale;

    Vector3 _currentScale;

    void Start()
    {
        _originalScale = transform.localScale;

        _currentScale = offset;

        Scale(_currentScale);
    }

    public void Scale(Vector3 offset)
    {
        if (easeMode == Ease.Unset)
            easeMode = Ease.InOutSine;

        transform.DOScale(offset, speed).SetDelay(0.1f).SetEase(easeMode).OnComplete(() =>
        {
            Scale(_currentScale);

            _currentScale = _currentScale == this.offset ? _originalScale : this.offset;
        });
    }


    void OnEnable() => this.gameObject.transform.DOPlay();

    void OnDisable() => this.gameObject.transform.transform.DOPause();
}
