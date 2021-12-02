using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoss : MonoBehaviour
{
    private Text uiText;
    private GameObject[] answerTxtGO;
    private GameObject UIPanel;
    
    void Start()
    {
        uiText =  GameObject.Find("UIText").GetComponent<Text>();
        answerTxtGO = GameObject.FindGameObjectsWithTag("AnswerTxt");
        UIPanel = GameObject.Find("UIPanel");
        if(uiText != null && answerTxtGO != null)
        {
            initializeQuestion();
            initializeAnswer();
        }
    }

    private void initializeQuestion()
    {
        uiText.text = GameData.instance.getQuestionArray()[0];
    }

    private void initializeAnswer()
    {
        for (int i = 0; i < answerTxtGO.Length; i++)
        {
            answerTxtGO[i].GetComponent<Text>().text = GameData.instance.getAnswerArray()[0, i];
        }
    }

    public void displayAttackText()
    {
        uiText.text = "Choose an attack!!!";
    }

    public void displayAttackMoves()
    {
        for (int i = 0; i < answerTxtGO.Length; i++)
        {
            answerTxtGO[i].GetComponent<Text>().text = GameData.instance.getAttackMovesArray()[i];
        }
    }

    public void displayQuestionAndAnswer()
    {
        int questionIndex = GameData.instance.getQuestionIndex();

        uiText.text = GameData.instance.getQuestionArray()[questionIndex];

        for (int i = 0; i < answerTxtGO.Length; i++)
        {
            answerTxtGO[i].GetComponent<Text>().text = GameData.instance.getAnswerArray()[questionIndex, i];
        }
    }

    public void enableUI()
    {
        UIPanel.SetActive(true);
    }

    public void disableUI()
    {
        UIPanel.SetActive(false);
    }
}
