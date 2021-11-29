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
    private string[] attackMoves;
    private int currentScore;
    private Highscore[] highscoreDB;

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
        currentScore = 0;
        highscoreDB = new Highscore[5];
        initializeQuestionArray();
        initializeAnswerChoicesArray();
        initializeAnswerArray();
        initializeAttackMovesArray();
    }

    private void initializeAttackMovesArray()
    {
        attackMoves = new string []
        {
            @"Shoot Earth",

            @"Shoot Fire",

            @"Shoot Water",

            @"Shoot Air",
        };
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
                }",

            // question 5
            @"The default value of a static integer variable of a class in Java is",

            // question 6
            @"To prevent any method from overriding, we declare the method as",

            // question 7
            @"Which of the following variable declaration would NOT compile in a java program?",

            // question 8
            @"All exception types are subclasses of the built-in class",

            // question 9
            @"In java, objects are passed as",

            // question 10
            @"What would the argument passing method be which is used by the above Program – III?",
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
            { "return sum should be outside the for-loop", "nothing is wrong with the code", "int i should start at 0", "sumOfSquares should return void" },

            // answers[4][0] answers[4][1] answers[4][2] answers[4][3]
            { "0", "1", "Garbage value", "null" },
            
            // answers[5][0] answers[5][1] answers[5][2] answers[5][3]
            { "static", "const", "final", "abstract" },

            // answers[6][0] answers[6][1] answers[6][2] answers[6][3]
            { "int var", "int VAR", "int var1", "int 1_var" },
            
            // answers[7][0] answers[7][1] answers[7][2] answers[7][3]
            { "Exception", "RuntimeException", "Error", "Throwable" },
            
            // answers[8][0] answers[8][1] answers[8][2] answers[8][3]
            { "Net Beans", "Borland’s Jbuilder", "Symantec’s Visual Café", "Microsoft Visual J++" },

            // answers[9][0] answers[9][1] answers[9][2] answers[9][3]
            { "Call by value", "Call by reference", "Call by java.lang class", "Call by compiler" },
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
            "return sum should be outside the for-loop",

            // question 5 answer {correctAnswers[4]) 
            "0",

            // question 6 answer {correctAnswers[5]) 
            "final",

            // question 7 answer {correctAnswers[6]) 
            "int 1_var",

            // question 8 answer {correctAnswers[7]) 
            "Throwable",

            // question 9 answer {correctAnswers[8]) 
            "Symantec’s Visual Café",

            // question 10 answer {correctAnswers[9]) 
            "Call by value",
        };
    }

    public void addScore()
    {
        this.currentScore = this.currentScore + 1;
    }

    public void setQuestionIndex()
    {
        this.questionIndex = questionIndex + 1;
    }

    public int getQuestionIndex()
    {
        return this.questionIndex;
    }

    public string [] getAttackMovesArray()
    {
        return attackMoves;
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

    public int getScore()
    {
        return this.currentScore;
    }

    public Highscore[] getHighScoreDB()
    {
        return highscoreDB;
    }

    private void addHighScore()
    {
        for (int i = 0; i < highscoreDB.Length; i++)
        {
            if(highscoreDB[i] == null)
            {
                highscoreDB[i] = new HB(playerName, currentScore);
                return;
            }
        }
        bubbleSort(highscoreDB);
    }

    private void bubbleSort(HB[] highscore)
    {
        int n = highscore.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (highscore[j].getCurrentScore() < highscore[j + 1].getCurrentScore())
                {
                    HB temp = highscore[j];
                    highscore[j] = highscore[j + 1];
                    highscore[j + 1] = temp;
                }
    }
}