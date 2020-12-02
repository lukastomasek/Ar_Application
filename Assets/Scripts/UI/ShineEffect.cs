using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShineEffect : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float maxX;
    [SerializeField] float delay = 0.5f;
    [SerializeField] Ease ease;
    [SerializeField] GameObject target;

    private void Start()
    {
        if(maxX == 0)
        {
            float width = GetComponent<Image>().GetComponent<RectTransform>().rect.width * 2;
            maxX = width;
        }

        Shine();
    }
    private void OnEnable() => target.transform.DOPlay();

    private void OnDisable() => target.transform.DOPause();

    void Shine()
    {
        target.transform.DOMoveX(maxX, speed).SetDelay(delay).SetEase(ease).OnComplete(() =>
        {
            target.transform.DOMoveX(-maxX, 0f);
            Shine();
        });
    }
}
