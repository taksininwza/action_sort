using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CorrectAnswer
    {
        get; private set;
    }
    public int QuestionSeen
    {
        get; private set;
    }
    public void IncrementCorrentAnswer()
    {
        this.CorrectAnswer++;
    }
    public void IncrementQuestionSeen()
    {
        this.QuestionSeen++;
    }
    public int Percent
    {
        get
        {
            return Mathf.RoundToInt(CorrectAnswer / (float)QuestionSeen * 100);
        }
    }
}
