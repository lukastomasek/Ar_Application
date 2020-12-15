using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LukasScripts;
using System;

public class Enemy : MonoBehaviour
{
    Animator _anim;
    HelperClass _helperClass;

    public static Action onEnemyTurn;

    [HideInInspector]
    public Health health;

    [SerializeField] ParticleSystem[] effect;

    [Space]
    [Header("Settings")]
    [SerializeField] [Range(10f, 30f)] float minDamage;
    [SerializeField] [Range(35f, 60f)] float maxDamage;

    public float GetDamage { get; private set; }

    public bool EnemysTurn { get; set; }

    private void OnEnable()
    {
        Player.onDamage += GetHurt;
    }

    private void OnDisable()
    {
        Player.onDamage -= GetHurt;
    }

    private void Start()
    {
        EnemysTurn = false;
        _anim = GetComponent<Animator>();
        _helperClass = new HelperClass();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void Attack()
    {
        //int random = _helperClass.RandomNumber(0, 2);
        Debug.Log("enemy attacking");
        _anim.Play("attack_1");
        GetDamage = _helperClass.DealDamage(minDamage, maxDamage);
        health.DealDamage(GetDamage);

    }

  

    void GetHurt()
    {
        _anim.Play("panic");
    }

    public void PlayAttackEffect()
    {
        GameplayAudio.instance.PlayButtonSound();

        foreach (var p in effect)
            p.Play();
    }
}
