using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public bool IsComplete;
    [Header("ProgressBar")]
    [SerializeField] Slider slider;
    [Header("Questions")]
    [SerializeField] List<QuestionSO> questionSOList = new List<QuestionSO>();
    [SerializeField] TextMeshProUGUI questionTMP;
    QuestionSO questionSO;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;

    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Score")]
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI scoreTMP;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    [SerializeField] Timer timer;

    bool hasAnswer;
    private void Start()
    {
        slider.maxValue = questionSOList.Count;
        slider.value = 0;
        //getNextquestion();
    }
    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextquestion)
        {
            if (slider.value == slider.maxValue)
            {
                IsComplete = true;
                return;
            }
            hasAnswer = false;
            getNextquestion();
            timer.loadNextquestion = false;
        }
        else if (hasAnswer == false && timer.isAnsweringQuestion == false)
        {
            displayAnswer(-1);
            setButtonState(false);
        }
    }

    private void getNextquestion()
    {
        if (questionSOList.Count > 0)
        {
            setButtonState(false);
            setButtonDefaultSprite();
            getRandomquestion();
            displayQuestion();
            setButtonState(true);
            slider.value++;
            scoreManager.IncrementQuestionSeen();
        }

    }

    private void getRandomquestion()
    {
        int randomIndex = UnityEngine.Random.Range(0, questionSOList.Count);
        questionSO = questionSOList[randomIndex];
        if (questionSOList.Contains(questionSO))
        {
            questionSOList.Remove(questionSO);
        }
    }

    private void displayQuestion()
    {
        questionTMP.text = questionSO.Question;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI tmp = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            tmp.text = questionSO.Answers[i];
        }
    }

    public void OnClickAnswerButton(int buttonIndex)
    {
        hasAnswer = true;
        displayAnswer(buttonIndex);
        setButtonState(false);

        timer.CancleTimer();
    }

    private void displayScore()
    {
        scoreTMP.text = "Score: " + scoreManager.Percent + "%";
    }

    private void displayAnswer(int buttonIndex)
    {
        Image buttonImg;
        int correctIndex = questionSO.CorrectAnswerIndex;
        if (buttonIndex == correctIndex)
        {
            questionTMP.text += " Correct!";
            buttonImg = answerButtons[buttonIndex].GetComponent<Image>();
            scoreManager.IncrementCorrentAnswer();
        }
        else
        {
            questionTMP.text = "Sorry, correct answer is " + questionSO.Answers[correctIndex];
            buttonImg = answerButtons[correctIndex].GetComponent<Image>();
        }
        buttonImg.sprite = correctAnswerSprite;
        displayScore();
    }

    private void setButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    private void setButtonDefaultSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImg = answerButtons[i].GetComponent<Image>();
            buttonImg.sprite = defaultAnswerSprite;
        }
    }
}
