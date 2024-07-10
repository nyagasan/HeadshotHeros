using UnityEngine;
using UnityEngine.UI;

public class RawImageFadeInOut : MonoBehaviour
{
    // フェードイン・フェードアウトのスピード
    public float fadeSpeed = 0.7f;

    // フェードの現在の透明度
    private float alpha = 0.0f;

    // フェードが進行中かどうかのフラグ
    private bool isFadingIn = true;

    // RawImageコンポーネント
    private RawImage rawImage;

    void Start()
    {
        // RawImageコンポーネントを取得
        rawImage = GetComponent<RawImage>();
        // RawImageの初期色を設定（ここでは透明度のみ操作）
        Color color = rawImage.color;
        color.a = alpha;
        rawImage.color = color;
    }

    void Update()
    {
        // フェードインまたはフェードアウトを進行
        if (isFadingIn)
        {
            alpha += fadeSpeed * Time.deltaTime;
            if (alpha >= 1.0f)
            {
                alpha = 1.0f;
                isFadingIn = false;
            }
        }
        else
        {
            alpha -= fadeSpeed * Time.deltaTime;
            if (alpha <= 0.0f)
            {
                alpha = 0.0f;
                isFadingIn = true;
            }
        }

        // RawImageの色を更新
        Color color = rawImage.color;
        color.a = alpha;
        rawImage.color = color;
    }
}