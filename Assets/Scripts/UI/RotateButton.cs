using UnityEngine;
using DG.Tweening;

public class RotateButton : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float angle = 180f;
    [SerializeField] float delayToDefault = 2f;
    [SerializeField] Ease ease;

    public void RotateUI()
    {
        transform.DORotate(new Vector3(0, 0, angle), speed).SetEase(ease).OnComplete(() =>
        {
            Invoke("RotateToDefault", delayToDefault);
        });
    }

    void RotateToDefault()
    {
        transform.DORotate(new Vector3(0, 0, 0), 0f);
    }
}
