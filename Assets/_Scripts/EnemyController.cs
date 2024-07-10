using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // Z軸方向の移動速度
    public float xMoveRange = 5f; // X軸の移動範囲制限
    public float xMoveSpeed = 1f; // X軸方向の移動速度
    private Vector3 randomDirection;

    void Start()
    {
        SetRandomDirection();
    }

    void Update()
    {
        // Z軸方向に移動
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        // X軸方向にランダムに移動
        transform.Translate(randomDirection * xMoveSpeed * Time.deltaTime, Space.World);

        // X軸の移動範囲を制限
        if (transform.position.x < -xMoveRange || transform.position.x > xMoveRange)
        {
            SetRandomDirection();
        }
    }

    void SetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, 0).normalized;
    }
}