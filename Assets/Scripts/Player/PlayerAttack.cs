using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerHealth pH;
    private PlayerController pC;
    private float attackRange = 1f;
    private float attackRadius = 1f;
    private float attackDamage = 20f;
    private float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;
    Vector2 direction = Vector2.up;
    Vector2 attackPosition;
    void Start()
    {
        pH = GetComponent<PlayerHealth>();
        pC = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (pH.IsDead) return;
        direction = pC.LastDirection;
        attackPosition = (Vector2)transform.position + direction * attackRange;
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }
    void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPosition, attackRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                EnemyHealth eH = hit.GetComponent<EnemyHealth>();
                if (eH != null)
                {
                    eH.TakeDamage(attackDamage);
                }
            }
        }
    }
    public void IncreaseDamage(float amount)
    {
        attackDamage += amount;
    }
    public void ReduceCooldown(float amount)
    {
        attackCooldown = Mathf.Max(0.05f, attackCooldown - amount);
    }
    private void OnDrawGizmosSelected()
    {
        // 기즈모 색상을 빨간색으로 설정
        Gizmos.color = Color.red;

        // 현재 위치를 중심으로 attackRadius 크기의 와이어(선) 구체(Sphere)를 그림
        Gizmos.DrawWireSphere(attackPosition, attackRadius);
    }
}
 