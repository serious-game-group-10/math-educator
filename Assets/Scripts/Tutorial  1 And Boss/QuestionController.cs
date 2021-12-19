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
    [SerializeField] GameObject attackChoicesPanel;


    [SerializeField] GameObject[] questionImages;
    [SerializeField] int questionIndex = 0;
    //3, 3, 3, 1, 1, 2, 2, 2, 4, 1
    private int[] correctAnswerList = { 1, 3, 4, 2, 3 };
    private int currentQuestionAnswer;
    private int playerAnswer;

    private void Start()
    {
        if (robotEnemy == null)
            robotEnemy = GameObject.Find("Enemy");

        if (uiController == null)
            uiController = GameObject.Find("GUIcontroller").GetComponent<UIController>();

        if (enemy == null)
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyWeapon>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (weapon == null)
            weapon = player.GetComponent<Weapon>();

        if (attackChoicesPanel == null)
            attackChoicesPanel = GameObject.Find("AttackChoicesPanel");

        // Coding Questions
        if (questionImages == null)
            questionImages = GameObject.FindGameObjectsWithTag("Question");

        foreach (GameObject qImg in questionImages)
            qImg.SetActive(false);

        questionImages[questionIndex].SetActive(true); // display the first question
        currentQuestionAnswer = correctAnswerList[questionIndex]; // set the correct answer choice
    }

    public void DisplayNextQuestion()
    {
        IncrementQuestionCounter();

            Debug.Log(questionIndex);
        if (questionIndex < correctAnswerList.Length)
        {
            uiController.DisplayQuestionPanel();
            questionImages[questionIndex].SetActive(true);
            currentQuestionAnswer = correctAnswerList[questionIndex];
        }
        else
        {
            uiController.HideQuestionPanel();
            Debug.Log("Finish");
        }
    }

    private void checkAnswer(int answerChoice)
    {
        playerAnswer = answerChoice;
        if (playerAnswer == currentQuestionAnswer)
        {
            uiController.HideQuestionPanel();
            attackChoicesPanel.SetActive(true);
            //weapon.ShootOne();
            //DisplayNextQuestion();
        }
        else
        {
            uiController.HideQuestionPanel();
            enemy.GenericAttack();
            uiController.ShowIncorrect();
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
}
