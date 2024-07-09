using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 追従するターゲット（自機）
    public Vector3 offset; // カメラの位置オフセット
    public float smoothSpeed = 0.125f; // カメラの追従スピード

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // 目標位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // スムーズに追従
        transform.position = smoothedPosition;

        transform.LookAt(target); // 常にターゲットを向く
    }
}