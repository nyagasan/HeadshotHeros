using UnityEngine;
using UnityEngine.UI;

public class VisionBoss : MonoBehaviour
{
    public int maxHealth = 1000; // VisionBossの最大HP
    private int currentHealth;
    public Slider healthSlider; // ヘルスバー
    public PlayerController player; // プレイヤーへの参照

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // VisionBossが死亡したときの処理
        Debug.Log("VisionBoss died!");
        player.AddScore(599800); // スコアを加算
        Destroy(gameObject);
    }
}