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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // 回転処理（オプション）
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // 弾の発射（スペースキー）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // 弾を発射するメソッド
    void Shoot()
    {
        // 弾を発射する処理をここに追加
        Debug.Log("Shoot!");
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10f;
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