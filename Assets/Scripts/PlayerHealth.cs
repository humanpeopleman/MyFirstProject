using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth = 100.0f;
    private float health;

    private bool isDead = false;
    public bool IsDead => isDead;
    private float nextDamageTime = 0f;
    private float damageInterval = 1.0f;
    private void Start()
    {
        health = maxHealth;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Enemy") && Time.time >= nextDamageTime)
        {
            health = Mathf.Max(0, health - 10.0f);
            Debug.Log(10 + "만큼의 피해!\t" + "현재 체력 : " + health);
            if (health <= 0)
            {
                Debug.Log("게임 오버");
                isDead = true;
                
            }
            nextDamageTime = Time.time + damageInterval;
        }
    }
}
