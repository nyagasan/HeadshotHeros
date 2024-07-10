using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20; // 弾のダメージ量

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent(out VisionBoss visionBoss))
            {
                visionBoss.TakeDamage(damage);
            }
            else if (other.TryGetComponent(out Quest3 quest3))
            {
                quest3.TakeDamage(damage);
            }
            Destroy(gameObject); // 弾を破壊
        }
    }
}