using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int score = 0;
    public int hp = 5; // 自機のHP
    public float bulletStrength = 1f; // 弾の強さ
    public float gameTime = 60f; // 指定時間（秒）
    public TMP_Text moneyText; // スコア表示
    public TMP_Text lifeText; // 残HP表示
    public TMP_Text timeText; // 残り時間表示

    private float currentTime;

    void Start()
    {
        currentTime = gameTime;
        UpdateUI();
    }

    void Update()
    {
        // 移動処理
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // 弾の発射（スペースキー）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        // ゲームオーバー処理
        if (hp <= 0)
        {
            GameOver();
        }

        // 残り時間の更新
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            GameClear();
        }
        UpdateUI();
    }

    void Shoot()
    {
        // 弾を発射する処理
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * 10f * bulletStrength; // Z軸正方向に発射
        bulletRb.useGravity = false; // 重力を無効にする
        Debug.Log("Shoot!");
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        UpdateUI();
        if (hp <= 0)
        {
            GameOver();
        }
    }

    public void UpgradeBullet()
    {
        bulletStrength = 2f; // 弾の強さを2倍にする
        Debug.Log("Bullet Upgraded! Strength: " + bulletStrength);
    }

    public void AddScore(int points)
    {
        score += points; // スコア加算
        UpdateUI();
        Debug.Log("Score: " + score);
    }

    void GameOver()
    {
        // ゲームオーバー時の処理
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // シーンを再読み込みする
    }

    void GameClear()
    {
        // ゲームクリア時の処理
        Debug.Log("Game Clear");
        // お金を貯蓄する処理（必要に応じて実装）
    }

    void UpdateUI()
    {
        // UIを更新する
        if (moneyText != null)
        {
            moneyText.text = "Score: " + score;
        }
        if (lifeText != null)
        {
            lifeText.text = "HP: " + hp;
        }
        if (timeText != null)
        {
            timeText.text = "Time: " + Mathf.Ceil(currentTime);
        }
    }
}
