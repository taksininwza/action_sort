using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private void Awake()
    {
        Singleton();
    }
    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    int score = 0;
    public int Score { get { return score; } }
    public void AddScore(int points)
    {
        score += points;
    }
    public void Reset()
    {
        score = 0;
    }
}
