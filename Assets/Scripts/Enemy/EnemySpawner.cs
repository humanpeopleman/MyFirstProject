using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnTimer = 0f;
    [SerializeField] private float spawnRadius = 8f;
    [SerializeField] private int maxEnemies = 10;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer -= spawnInterval;
            spawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length >= maxEnemies)
            return;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = player.position + (Vector3)(randomDirection * spawnRadius);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
