using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 4.0f;
    private Transform target;
    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player 태그가 지정된 오브젝트를 찾을 수 없습니다.");
            enabled = false;
            return;
        }
        target = player.transform;
    }
    void FixedUpdate()
    {
        movement = (target.position - transform.position).normalized;
        // Vector2 기준으로 다음 프레임에 도달할 목적지 좌표 계산
        Vector2 nextPosition = rb.position + movement * speed * Time.fixedDeltaTime;

        // 목적지로 물리 충돌을 계산하며 이동
        rb.MovePosition(nextPosition);
    }
}
