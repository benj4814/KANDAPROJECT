using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public int currentQuestion = 0;

    public static QuizManager Instance;

    public Question[] questions;
    private void Awake()
    {
        // It checks if an instance of the QuizManager already exists and either sets  
        //the Instance variable to this instance or destroys the duplicate instance.
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

    public void QuestionCompleted()
    {
        currentQuestion++;

        if (QuizCompleted())
        {
            SceneManager.LoadScene("Game Is Finished"); // Replace with the name of the new scene to load
        }
    }

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
