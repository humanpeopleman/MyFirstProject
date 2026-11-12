using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth = 100.0f, health;
    public float MaxHealth => maxHealth;
    public float Health => health;
    public event Action<float, float> OnHealthChanged;

    private bool isDead = false;
    public bool IsDead => isDead;
    public event Action OnPlayerDead;

    private float nextDamageTime = 0f, damageInterval = 1.0f; //공격 받기
    private void Awake()
    {
        health = maxHealth;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Enemy") && Time.time >= nextDamageTime)
        {
            TakeDamage();
        }
    }
    private void TakeDamage(float damage = 10f)
    {
        health = Mathf.Max(0, health - damage);
        OnHealthChanged?.Invoke(maxHealth, health);
        if (health <= 0)
        {
            isDead = true;
            OnPlayerDead?.Invoke();
        }
        nextDamageTime = Time.time + damageInterval;
    }
    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
        health += amount;
        OnHealthChanged?.Invoke(maxHealth, health);
    }
}
