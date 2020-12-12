using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LukasScripts;

public class Enemy : MonoBehaviour
{
    Animator _anim;
    HelperClass _helperClass;
    Health _health;

    [Space]
    [Header("Settings")]
    [SerializeField] [Range(10f, 30f)] float minDamage;
    [SerializeField] [Range(35f, 60f)] float maxDamage;

    public float GetDamage { get; private set; }


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
        _anim = GetComponent<Animator>();
        _helperClass = new HelperClass();
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Attack()
    {
        int random = _helperClass.RandomNumber(0, 2);

        if (random == 1)
        {
            _anim.Play("attack_1");
            GetDamage = _helperClass.DealDamage(minDamage, maxDamage);
            _health.DealDamage(GetDamage);
        }
        else
        {
            _anim.Play("attack_2");
            GetDamage = _helperClass.DealDamage(minDamage, maxDamage);
            _health.DealDamage(GetDamage);
        }
    }


    void GetHurt()
    {
        _anim.Play("panic");
    }

    public void PlayAttackEffect()
    {

    }
}
