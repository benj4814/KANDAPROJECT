using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroQuiz : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        
            Question myQuestion = QuizManager.Instance.GetQuestion(0);

            bool answer = myQuestion.ValidateAnswer("Hejsa");
            
            myQuestion.IsAnsweredCorrect();

            Debug.Log(myQuestion + "Answer" + myQuestion.answer);

            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                QuizManager.Instance.ValidateQuestionAnswer(0, "Hejsa");
            }
    }
}
