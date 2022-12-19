using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] Health player;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    private void Start()
    {
        hpSlider.maxValue = player.HP;
    }
    private void Update()
    {
        hpSlider.value = player.HP;
        scoreText.text = " Score: " + ScoreManager.Instance.Score.ToString("00000000000000");
    }
}
