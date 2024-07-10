using UnityEngine;
using TMPro;

public class ResultController : MonoBehaviour
{
    public TMP_Text moneyText; // スコア表示用のTextMeshPro

    void Start()
    {
        moneyText.text = "" + PlayerController.RootScore;
    }
}