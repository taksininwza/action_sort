using UnityEngine;

[CreateAssetMenu(menuName = "Quize Question", fileName = "Question")]
public class QuestionSO : ScriptableObject
{
    // [TextArea(1, 6)]
    [SerializeField] string question = "question text";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex = 0;
    public string Question
    {
        get { return this.question; }
    }
    public string[] Answers
    {
        get { return this.answers; }
    }
    public int CorrectAnswerIndex
    {
        get { return this.correctAnswerIndex; }
    }
}
