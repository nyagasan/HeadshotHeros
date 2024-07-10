using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject quest3Prefab; // Quest3のプレハブ
    public float spawnRate = 1f; // 何秒ごとに敵をスポーンさせるか
    public float spawnRangeX = 5f; // X軸のスポーン範囲
    public float spawnPosZ = -10f; // スポーン位置のZ座標
    public Transform playerTransform; // プレイヤーのTransform

    private void Start()
    {
        InvokeRepeating("SpawnQuest3", 0f, spawnRate);
    }

    void SpawnQuest3()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 0, spawnPosZ);
        GameObject quest3 = Instantiate(quest3Prefab, spawnPosition, Quaternion.identity);
        
        // Quest3のスクリプトにPlayerControllerへの参照を設定
        Quest3 quest3Script = quest3.GetComponent<Quest3>();
        quest3Script.player = playerTransform.GetComponent<PlayerController>();
    }
}