using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 700f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int score = 0;
    private float bulletStrength = 1f;

    void Update()
    {
        // 移動処理
        // 移動処理（入力の符号を反転）
        float moveHorizontal = -Input.GetAxis("Horizontal");
        float moveVertical = -Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // 弾の発射（スペースキー）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // 弾を発射するメソッド
    void Shoot()
    {
        // 弾を発射する処理
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.right * 10f * bulletStrength; // X軸正方向に発射
        Debug.Log("Shoot!");
    }
    
    public void UpgradeBullet()
    {
        bulletStrength *= 1.5f; // 弾の強化（例: 1.5倍）
        Debug.Log("Bullet Upgraded! Strength: " + bulletStrength);
    }

    public void AddScore(int points)
    {
        score += points; // スコア加算
        Debug.Log("Score: " + score);
    }
}