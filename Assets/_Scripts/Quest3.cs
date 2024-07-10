using UnityEngine;

public class Quest3 : MonoBehaviour
{
    public int maxHealth = 3; // Quest3の最大HP
    private int currentHealth;
    public PlayerController player; // プレイヤーへの参照

    void Start()
    {
        currentHealth = maxHealth;
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
    }
}