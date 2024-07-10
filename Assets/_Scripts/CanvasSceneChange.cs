using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadSceneOnClick : MonoBehaviour, IPointerClickHandler
{
    // 移動先のシーン名
    public string sceneName = "main";

    // Canvasがクリックされたときに呼び出されるメソッド
    public void OnPointerClick(PointerEventData eventData)
    {
        // シーンをロードする
        SceneManager.LoadScene(sceneName);
    }
}