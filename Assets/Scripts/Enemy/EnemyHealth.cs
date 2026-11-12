using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float maxHealth = 100.0f, health;
    private bool isDead = false;
    [SerializeField] private GameObject expOrb;
    void Start()
    {
        health = maxHealth;

    }
    public void TakeDamage(float damage)
    {
        if (isDead) return;
        health = Mathf.Max(0, health - damage);
        if (health <= 0) {
            isDead = true;
            Instantiate(expOrb, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
