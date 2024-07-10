using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // 回転速度を設定するための変数
    public float rotationSpeed = 5f;

    void Update()
    {
        // y軸を中心に回転させる
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
