using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1f; // 移動速度を調整
    private Vector3 randomDirection;
    private float changeDirectionTime = 2f;
    private float changeDirectionTimer;
    public float moveRange = 5f; // 移動範囲を設定

    void Start()
    {
        SetRandomDirection();
        changeDirectionTimer = changeDirectionTime;
    }

    void Update()
    {
        // ランダムに移動
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);

        // 一定時間ごとに方向を変える
        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer <= 0)
        {
            SetRandomDirection();
            changeDirectionTimer = changeDirectionTime;
        }

        // 移動範囲を制限
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, -moveRange, moveRange),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -moveRange, moveRange)
        );
        transform.position = clampedPosition;
    }

    void SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        randomDirection = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)).normalized;
    }
}