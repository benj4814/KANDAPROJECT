using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    public string question;
    public string[] answers;
    private bool isCorrect;


// Her gør vi så der ikke bliver tjekket for punktum, komma og småbogstaver //
    public bool ValidateAnswer(string userAnswer)
    {
        foreach(string answer in answers)
        {
            userAnswer = userAnswer.Replace(".", "");
            userAnswer = userAnswer.Replace(",", "");

            if (userAnswer.ToLower() == answer.ToLower())
            {
                SetCorrect();
                return true;
            }
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