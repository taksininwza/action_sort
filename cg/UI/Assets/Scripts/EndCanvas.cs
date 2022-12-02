using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCanvas : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreTMP;
    ScoreManager scoreManager;
    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void DisplayScore()
    {
        scoreTMP.text = "Score: " + scoreManager.Percent + "%";
    }
}
