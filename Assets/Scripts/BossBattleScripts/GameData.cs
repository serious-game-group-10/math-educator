using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private int questionIndex;
    private string[] questions;
    private string[,] answers;
    private string[] correctAnswers;

    public static GameData instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        questionIndex = 0;
        initializeQuestionArray();
        initializeAnswerChoicesArray();
        initializeAnswerArray();
    }

    private void initializeQuestionArray()
    {
        questions = new string[]
        {
            // question 1 (questions[0])
            @"What is the runtime of the following code?
                public void printTuples(x) {
                    for (int i = 0; i < x; i++) {
                        for (int j = 0; j < x; j++) {
                            System.out.println(i + j);
                        }
                    }
                }", 

            // question 2 (questions[1])
            @"What is the term for two functions with the same method signature, that differ only in their parameter types?",

            // question 3 (questions[2])
            @"Which of these data types is not a primitive in Java?",

            // question 4 (questions[3])
            @"What is wrong with the following code?
                public int sumOfSquares(n) {
                    int sum = 0;
                    for (int i = 1; i <= n; i++) {
                        sum += n * n;
                        return sum;
                    }
                }"
        };
    }

    private void initializeAnswerChoicesArray()
    {
        answers = new string[,]
        {
            // answer choices for the first question
            // answers[0][0] answers[0][1] answers[0][2] answers[0][3]
            { "O(n)", "O(n^2)", "O(nlogn)", "O(1)" }, 

            // answer choices for the second question 
            // answers[1][0] answers[1][1] answers[1][2] answers[1][3]
            { "Overloaded", "Override", "Twin Methods", "Duplicate Methods" }, 

            // answers[2][0] answers[2][1] answers[2][2] answers[2][3]
            { "int", "double", "boolean", "String" }, 

            // answers[3][0] answers[3][1] answers[3][2] answers[3][3]
            { "return sum should be outside the for-loop", "nothing is wrong with the code", "int i should start at 0", "sumOfSquares should return void" }
        };
    }

    private void initializeAnswerArray()
    {
        correctAnswers = new string[]
        {
            // question 1 answer (correctAnswers[0])
            "O(n^2)", 

            // question 2 answer (correctAnswers[1])
            "Overloaded",

            // question 3 answer (correctAnswers[2])
            "String",

            // question 4 answer {correctAnswers[3]) 
            "return sum should be outside the for-loop"
        };
    }

    public void setQuestionIndex(int questionIndex)
    {
        this.questionIndex = questionIndex;
    }

    public int getQuestionIndex()
    {
        return this.questionIndex;
    }

    public string[] getQuestionArray()
    {
        return questions;
    }

    public string[,] getAnswerArray()
    {
        return answers;
    }

    public string[] getCorrectAnswers()
    {
        return correctAnswers;
    }
}