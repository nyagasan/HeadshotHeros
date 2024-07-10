using UnityEngine;

public class Quest3 : MonoBehaviour
{
    public int maxHealth = 3; // Quest3の最大HP
    private int currentHealth;
    public PlayerController player; // プレイヤーへの参照
    public float moveSpeed = 3f; // Z軸方向の移動速度
    public float xMoveRange = 5f; // X軸の移動範囲制限
    public float xMoveSpeed = 1f; // X軸方向の移動速度

    private Vector3 randomDirection;

    void Start()
    {
        currentHealth = maxHealth;
        SetRandomDirection();
    }

    void Update()
    {
        // Z軸負方向に移動
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);

        // X軸方向にランダムに移動
        transform.Translate(randomDirection * xMoveSpeed * Time.deltaTime, Space.World);

        // X軸の移動範囲を制限
        if (transform.position.x < -xMoveRange || transform.position.x > xMoveRange)
        {
            SetRandomDirection();
        }

        // Z軸の位置をチェックして、プレイヤーを越えたら削除
        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }

    void SetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, 0).normalized;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Quest3が死亡したときの処理
        Debug.Log("Quest3 died!");
        player.AddScore(74800); // スコアを加算
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(1); // 自機のHPを減らす
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            TakeDamage(1); // 弾が当たった時のダメージを適用
            Destroy(other.gameObject); // 弾を破壊
        }
    }
}