using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LukasScripts;

public class Player : MonoBehaviour
{
    public static Action onDamage;

    public bool PlayerTurn { get; set; }

    [SerializeField] GameObject effect;
    [SerializeField] Enemy enemy;

    Animator _anim;
    HelperClass _helperClass;
    [HideInInspector]
    public Health health;
    ParticleSystem[] _particles;

    [Space]
    [Header("Settings")]
    [SerializeField] [Range(10f, 30f)] float minDamage;
    [SerializeField] [Range(35f, 60f)] float maxDamage;

    public float GetDamage { get; private set; }

    private void Start()
    {
       
        _anim = GetComponent<Animator>();
        _helperClass = new HelperClass();
        health = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Health>();
        _particles = effect.GetComponentsInChildren<ParticleSystem>();
    }

    public void Attack_1()
    {
        _anim.Play("attack_1");
        GetDamage = _helperClass.DealDamage(minDamage, maxDamage);
        health.DealDamage(GetDamage);
        //Debug.Log($"<color=green> dealed damage : {GetDamage} </color>");
        GameplayAudio.instance.PlayAttackSound();
        onDamage?.Invoke();
        EnemyTurn();
    }

    public void Attack_2()
    {
        _anim.Play("attack_2");
        health.DealDamage(GetDamage);
        GetDamage = _helperClass.DealDamage(minDamage, maxDamage);
        //Debug.Log($"<color=green> dealed damage : {GetDamage} </color>");
        GameplayAudio.instance.PlayAttackSound();
        onDamage?.Invoke();
        EnemyTurn();
    }

    public void Attack_3()
    {
        _anim.Play("attack_3");
        GetDamage = _helperClass.DealDamage(minDamage, maxDamage);
        health.DealDamage(GetDamage);
       // Debug.Log($"<color=green> dealed damage : {GetDamage} </color>");
        GameplayAudio.instance.PlayAttackSound();
        onDamage?.Invoke();
        EnemyTurn();
    }

    public void EnemyTurn()
    {
        GameController.instance.EnemyTurn();
    }

  
    public void PlayAttackEffect()
    {
        foreach (var p in _particles)
            p.Play();
    }
}
