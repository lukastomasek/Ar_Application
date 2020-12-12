using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Health : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Animator anim;
    public float CurrentHealth { get; set; }
    [SerializeField] [Range(10f, 100f)] float maxHealth = 100f;

    delegate void OnDied();
    event OnDied ondied;

    private void Start()
    {
        StartHealth();
    }

    private void OnEnable()
    {
        ondied += Dead;
    }

    private void OnDisable()
    {
        ondied -= Dead;
    }

    public void StartHealth()
    {
        CurrentHealth = maxHealth;
        healthSlider.value = CurrentHealth;
        healthSlider.maxValue = CurrentHealth;
        healthSlider.normalizedValue = CurrentHealth;
    }

    public void DealDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, maxHealth);
        CurrentHealth -= damage;
        healthSlider.value = CurrentHealth;

     

        if (CurrentHealth <= 0f)
        {
            ondied?.Invoke();
        }
    }

    public void Dead()
    {
        // show ui
        // restart level
        anim.Play("die");
        //Time.timeScale = 0f;
        Invoke("DisableSystems", 4f);
    }
    
    void DisableSystems()
    {
        anim.enabled = false;
    }

}
