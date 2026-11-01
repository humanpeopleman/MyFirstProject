using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float maxHealth = 100.0f;
    private float health;
    void Start()
    {
        health = maxHealth;

    }
    public void TakeDamage(float damage)
    {
        health = Mathf.Max(0, health - damage);
        Debug.Log("적에게 " + damage + "만큼의 피해!");
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
