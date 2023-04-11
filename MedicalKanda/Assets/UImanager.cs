using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI questionText;

    public TMP_InputField answerText;

    public static UImanager Instance;

    public void CheckAnswer()
    {
        bool correct = QuizManager.Instance.GetCurrentQuestion().ValidateAnswer(answerText.text);
        if (correct == true)
        {
            QuizManager.Instance.QuestionCompleted();

            if (QuizManager.Instance.QuizCompleted())
            {
                questionText.text = "Tillykke!";
            } else
            {
                Question question = QuizManager.Instance.GetCurrentQuestion();
                questionText.text = question.question;
            }
        } 
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Question question = QuizManager.Instance.GetCurrentQuestion();
        questionText.text = question.question; 
    }


}