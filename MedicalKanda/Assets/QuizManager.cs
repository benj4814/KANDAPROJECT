using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public int currentQuestion = 0;

    public static QuizManager Instance;

    public Question[] questions;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Question GetCurrentQuestion()
    {
        return questions[currentQuestion];
    }

// Plus et spørgsmål oveni hver gang et spørgsmål er besvaret rigtigt //
    public void QuestionCompleted()
    {
        currentQuestion++;
    }

// Tjek om quizzen er færdige ved at spørge om currentQuestion er større end quizzens længde //
    public bool QuizCompleted()
    {
        return !(currentQuestion < questions.Length);
    }



    public Question GetQuestion(int index)
    {
        index = Mathf.Clamp(index, 0, questions.Length - 1);
        return questions[index];
    }
}