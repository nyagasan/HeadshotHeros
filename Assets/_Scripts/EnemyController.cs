using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // Z軸方向の移動速度
    public float xMoveRange = 5f; // X軸の移動範囲制限
    public float xMoveSpeed = 1f; // X軸方向の移動速度
    public int damage = 10; // 自機に与えるダメージ
    public int points = 100; // 自機が得るポイント
    public int maxHealth = 100; // 敵の最大HP
    public Slider healthSlider; // HPを表示するスライダー

    private int currentHealth;
    private Vector3 randomDirection;

    void Start()
    {
        SetRandomDirection();

        // ヘルスの初期設定
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.AddScore(points);
            }
            TakeDamage(20); // 弾が当たった場合のダメージ量を設定
            Destroy(other.gameObject); // 弾を破壊
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 敵が死亡したときの処理
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
