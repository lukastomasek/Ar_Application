using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject effect;

    ParticleSystem[] _particles = null;
    const string fight_id = "attack_1";

    private void Start()
    {
        Debug.Log("<color=green> Testing </color>");

        if (anim == null)
        {
            anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }

        _particles = effect.GetComponentsInChildren<ParticleSystem>();
    }

    public void PlayFightAnimation()
    {
        anim.Play(fight_id);

        foreach (var p in _particles)
            p.Play();
    }
}
