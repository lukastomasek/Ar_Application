using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Slider healthSlider;

    public float CurrentHealth { get; set; }
    const float maxHealth = 100f;

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
    }

    public void DealDamage(float damage)
    {
        CurrentHealth -= damage;
        healthSlider.normalizedValue = CurrentHealth;

        if (CurrentHealth <= 0f)
        {
            ondied?.Invoke();
        }
    }

    public void Dead()
    {
        // show ui
        // restart level
        Time.timeScale = 0f;
    }

}
