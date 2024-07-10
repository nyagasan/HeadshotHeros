using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 1f; // 何秒ごとに敵をスポーンさせるか
    public float spawnRangeX = 5f; // X軸のスポーン範囲
    public float spawnPosZ = -10f; // スポーン位置のZ座標

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 0, spawnPosZ);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}