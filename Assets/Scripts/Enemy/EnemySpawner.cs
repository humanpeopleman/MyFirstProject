using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;

    [SerializeField] private float spawnInterval = 3f;
    private float spawnTimer = 0f;
    [SerializeField] private float spawnRadius = 8f;
    [SerializeField] private int maxEnemies = 10;

    [SerializeField] private GameManager gameManager;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        UpdateDifficulty();
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer -= spawnInterval;
            SpawnEnemy();
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
    private void UpdateDifficulty()
    {
        spawnInterval = Mathf.Max(1f, 3f - (gameManager.SurvivalTime / 30f) * 0.5f);
    }
}
