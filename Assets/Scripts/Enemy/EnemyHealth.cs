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
        Debug.Log("적에게 " + damage + "만큼의 피해!");
        if (health <= 0) {
            isDead = true;
            Instantiate(expOrb, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
