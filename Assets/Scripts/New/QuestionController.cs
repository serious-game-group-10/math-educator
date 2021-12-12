using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    [SerializeField] EnemyWeapon enemy;
    [SerializeField] GameObject robotEnemy;
    [SerializeField] GameObject player;
    [SerializeField] Weapon weapon;
    [SerializeField] UIController uiController;
    [SerializeField] GameObject dialogueUI;


    [SerializeField] GameObject[] questionImages;
    [SerializeField] int questionIndex = 0;

    private int[] correctAnswerList = { 1, 3, 4, 2, 3 };
    private int currentQuestionAnswer;
    private int playerAnswer;
    private const int DAMAGE_PER_CORRECT_QUESTION = 20;

    private void Start()
    {
        if (robotEnemy == null)
        {
            robotEnemy = GameObject.Find("Enemy");
        }

        if (uiController == null)
        {
            uiController = GameObject.Find("LevelController").GetComponent<UIController>();
        }

        if (enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyWeapon>();
        }

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (weapon == null)
        {
            weapon = player.GetComponent<Weapon>();
        }

        if (questionImages == null)
        {
            questionImages = GameObject.FindGameObjectsWithTag("Question");
        }

        foreach (GameObject qImg in questionImages)
        {
            qImg.SetActive(false);
        }

        questionImages[questionIndex].SetActive(true); // display the first question
        currentQuestionAnswer = correctAnswerList[questionIndex];
    }

    private void DisplayNextQuestion()
    {
        IncrementQuestionCounter();
        if (questionIndex < correctAnswerList.Length)
        {
            questionImages[questionIndex].SetActive(true);
            currentQuestionAnswer = correctAnswerList[questionIndex];
        }
        else
        {
            uiController.HideQuestionPanel();
        }
    }

    private void checkAnswer(int answerChoice)
    {
        playerAnswer = answerChoice;
        if (playerAnswer == currentQuestionAnswer)
        {
            uiController.HideQuestionPanel();
            weapon.ShootOne();
            DisplayNextQuestion();
        }
        else
        {
            uiController.HideQuestionPanel();
            enemy.RobotAttack();
            IncorrectMessage();
        }
    }

    public void AnswerA() 
    {
        checkAnswer(1);
    }
    public void AnswerB() 
    {
        checkAnswer(2);
    }
    public void AnswerC() 
    {
        checkAnswer(3);
    }
    public void AnswerD() 
    {
        checkAnswer(4);
    }

    private void IncrementQuestionCounter()
    {
        // hide the answered question
        questionImages[questionIndex].SetActive(false);
        questionIndex++;
    }

    private void IncorrectMessage()
    {
        uiController.ShowWrong();
    }
}
