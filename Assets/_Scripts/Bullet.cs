using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f; // 弾の寿命（秒）

    void Start()
    {
        // 一定時間後に弾を破棄する
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // グローバルY座標が一定位置を下回ったら弾を破棄する
        if (transform.position.y < -10f) // 例えばY座標が-10を下回ったら破棄
        {
            Destroy(gameObject);
        }
    }
}