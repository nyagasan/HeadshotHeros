using UnityEngine;

public class ItemController : MonoBehaviour
{
    public enum ItemType { MagicMouse, AppleGiftCard }
    public ItemType itemType;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect(other.gameObject);
            Destroy(gameObject);
        }
    }

    void ApplyEffect(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            switch (itemType)
            {
                case ItemType.MagicMouse:
                    // 弾の強化効果を実装
                    playerController.UpgradeBullet();
                    break;
                case ItemType.AppleGiftCard:
                    // スコア加算効果を実装
                    playerController.AddScore(100);
                    break;
            }
        }
    }
}