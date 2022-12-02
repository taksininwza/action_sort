using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Quiz quizCanvas;
    [SerializeField] EndCanvas endCanvas;

    private void Start()
    {
        quizCanvas.gameObject.SetActive(true);
        endCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (quizCanvas.IsComplete)
        {
            quizCanvas.gameObject.SetActive(false);
            endCanvas.gameObject.SetActive(true);
            endCanvas.DisplayScore();
        }
    }

    public void OnClickPlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
