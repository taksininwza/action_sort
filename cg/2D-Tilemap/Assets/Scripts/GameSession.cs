using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance { get; private set; }
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

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TMPro.TextMeshProUGUI liveText;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    private void Start()
    {
        liveText = GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0];
        scoreText = GetComponentsInChildren<TMPro.TextMeshProUGUI>()[1];
        updateLivesText();
        updateScoreText();
    }

    public void addScore(int points)
    {
        score += points;
        updateScoreText();
    }

    public void OnPlayerDeath()
    {
        if (playerLives > 1)
        {
            takeLife();
        }
        else
        {
            resetGameSession();
        }
    }

    private void takeLife()
    {
        playerLives--;
        updateLivesText();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void updateLivesText()
    {
        liveText.text = "Lives: " + playerLives.ToString();
    }

    private void updateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void resetGameSession()
    {
        GamePersist.Instance.Reset();
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }
}
