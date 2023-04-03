using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    public string question;
    public string answer;
    private bool isCorrect;

    public bool ValidateAnswer(string userAnswer)
    {
        if (userAnswer == answer)
        {
            SetCorrect();
            return true;
        }

        return false;
    }

    public bool IsAnsweredCorrect()
    {
        return isCorrect;
    }

    public void SetCorrect()
    {
        isCorrect = true;
    }
}