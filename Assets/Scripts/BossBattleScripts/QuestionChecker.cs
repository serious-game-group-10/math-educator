using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionChecker : MonoBehaviour
{
    private Player player;
    private Weapon playerWeapon;
    private Enemy enemy;
    private EnemyWeapon enemyWeapon;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerWeapon = player.GetComponent<Weapon>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        enemyWeapon = enemy.GetComponent<EnemyWeapon>();
    }

    public void checkAnswer(Button button)
    {
        if (GameData.instance.getQuestionIndex() == 0)
        {
            if (button.GetComponentInChildren<Text>().text != GameData.instance.getCorrectAnswers()[0])
            {
                enemyWeapon.Shoot();
            }
            else
            {
                GameData.instance.setQuestionIndex(1);
                playerWeapon.Shoot();
            }
        }
        else if (GameData.instance.getQuestionIndex() == 1)
        {
            if (button.GetComponentInChildren<Text>().text != GameData.instance.getCorrectAnswers()[1])
            {
                enemyWeapon.Shoot();
            }
            else
            {
                GameData.instance.setQuestionIndex(2);
                playerWeapon.Shoot();
            }
        }
        else if (GameData.instance.getQuestionIndex() == 2)
        {
            if (button.GetComponentInChildren<Text>().text != GameData.instance.getCorrectAnswers()[2])
            {
                enemyWeapon.Shoot();
            }
            else
            {
                GameData.instance.setQuestionIndex(3);
                playerWeapon.Shoot();
            }
        }
        else if (GameData.instance.getQuestionIndex() == 3)
        {
            if (button.GetComponentInChildren<Text>().text != GameData.instance.getCorrectAnswers()[3])
            {
                enemyWeapon.Shoot();
            }
            else
            {
                GameData.instance.setQuestionIndex(4);
                playerWeapon.Shoot();
            }
        }
    }
}