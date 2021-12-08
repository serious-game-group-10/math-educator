using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseChecker : MonoBehaviour
{
    private GameObject UIDisplay;
    private Text uiText;
    private UIBoss UIBoss;
    private Enemy enemy;
    private EnemyWeapon enemyWeapon;
    private Player player;
    private Weapon playerWeapon;

    void Start()
    {
        UIDisplay = GameObject.Find("UIDisplay");
        uiText =  GameObject.Find("UIText").GetComponent<Text>();
        UIBoss = GameObject.Find("UIDisplay").GetComponent<UIBoss>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        enemyWeapon = enemy.GetComponent<EnemyWeapon>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerWeapon = player.GetComponent<Weapon>();
    }

    public void checkChoices(Button button)
    {
        if(uiText.text != "Choose an attack!!!")
        {
            if (button.GetComponentInChildren<Text>().text != GameData.instance.getCorrectAnswers()[GameData.instance.getQuestionIndex()])
            {
                UIBoss.disableUI();
                enemyWeapon.RobotAttack();
            }
            else
            {
                UIBoss.displayAttackText();
                UIBoss.displayAttackMoves();
                GameData.instance.setQuestionIndex();
            }
        }else {
            if(button.GetComponentInChildren<Text>().text == GameData.instance.getAttackMovesArray()[0])
            {
                playerWeapon.Shoot();
                UIBoss.disableUI();
            } else if(button.GetComponentInChildren<Text>().text == GameData.instance.getAttackMovesArray()[1])
            {
                playerWeapon.Shoot();
                UIBoss.disableUI();
            } else if(button.GetComponentInChildren<Text>().text == GameData.instance.getAttackMovesArray()[2])
            {
                playerWeapon.Shoot();
                UIBoss.disableUI();
            } else if(button.GetComponentInChildren<Text>().text == GameData.instance.getAttackMovesArray()[3])
            {
                playerWeapon.Shoot();
                UIBoss.disableUI();
            }
        }
    }
}
        

