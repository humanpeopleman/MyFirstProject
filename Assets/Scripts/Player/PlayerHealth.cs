using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth = 100.0f, health;
    private bool isDead = false;
    public bool IsDead => isDead;
    private float nextDamageTime = 0f, damageInterval = 1.0f; //공격 받기
    public event Action OnPlayerDead;
    private void Start()
    {
        health = maxHealth;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Enemy") && Time.time >= nextDamageTime)
        {
            takeDamage();
        }
    }
    private void TakeDamage(float damage = 10f)
    {
        health = Mathf.Max(0, health - damage);
        Debug.Log(damage + "만큼의 피해!\t" + "현재 체력 : " + health);
        if (health <= 0)
        {
            isDead = true;
            OnPlayerDead?.Invoke();
        }
        nextDamageTime = Time.time + damageInterval;
    }
}
