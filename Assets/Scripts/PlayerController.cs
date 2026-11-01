using Unity.Jobs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerHealth pH;
    private Rigidbody2D rb;
    private float speed = 5f;
    private Vector2 movement;
    private Vector2 lastDirection = Vector2.up;
    public Vector2 LastDirection => lastDirection;
    private void Start()
    {
        pH = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(x, y).normalized;
        if (movement != Vector2.zero)
            lastDirection = movement;
    }
    void FixedUpdate()
    {
        if (pH.IsDead)
            return;
        // Vector2 기준으로 다음 프레임에 도달할 목적지 좌표 계산
        Vector2 nextPosition = rb.position + movement * speed * Time.fixedDeltaTime;

        // 목적지로 물리 충돌을 계산하며 이동
        rb.MovePosition(nextPosition);
    }
}
