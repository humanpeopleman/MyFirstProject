using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 4.0f;
    private Transform target;
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player 태그가 지정된 오브젝트를 찾을 수 없습니다.");
            enabled = false;
            return;
        }
        target = player.transform;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);
    }
}
