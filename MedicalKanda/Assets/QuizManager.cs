using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
   public static QuizManager Instance;

    public Question[] questions;
   private void Awake()
   {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
   }

   public bool ValidateQuestionAnswer(int index, string questionAnswer)
   {
    Question question = questions[index];
    if (question.answer == questionAnswer)
   {
    return true;
    }
   return false;
   }
    

   public Question GetQuestion(int index)
   {
    index = Mathf.Clamp(index, 0, questions.Length -1);
    return questions[index];
   }
}
