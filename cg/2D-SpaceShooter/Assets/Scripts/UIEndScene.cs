using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndScene : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    private void Start()
    {
        scoreText.text = " Score: " + ScoreManager.Instance.Score.ToString("000000000000");
    }
}
