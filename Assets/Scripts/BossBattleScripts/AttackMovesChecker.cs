using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackMovesChecker : MonoBehaviour
{
    private Text questionTxt;
    private GameObject[] answerTxtGO;

    void Start()
    {
        questionTxt = GameObject.FindGameObjectWithTag("QuestionText").GetComponent<Text>();
        answerTxtGO = GameObject.FindGameObjectsWithTag("AnswerTxt");
    }

    public void displayAttackMoves()
    {
        for (int i = 0; i < answerTxtGO.Length; i++)
        {
            answerTxtGO[i].GetComponent<Text>().text = GameData.instance.getAttackMovesArray()[i];
        }
    }
}
