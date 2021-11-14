using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuestion : MonoBehaviour
{
    private Text questionTxt;
    private GameObject[] answerTxtGO;

    void Start()
    {
        questionTxt = GameObject.FindGameObjectWithTag("QuestionText").GetComponent<Text>();
        answerTxtGO = GameObject.FindGameObjectsWithTag("AnswerTxt");
        initializeQuestion();
        initializeAnswer();
    }

    private void initializeQuestion()
    {
        questionTxt.text = GameData.instance.getQuestionArray()[0];
    }

    private void initializeAnswer()
    {
        for (int i = 0; i < answerTxtGO.Length; i++)
        {
            answerTxtGO[i].GetComponent<Text>().text = GameData.instance.getAnswerArray()[0, i];
        }
    }

    public void displayQuestionAndAnswer()
    {
        int questionIndex = GameData.instance.getQuestionIndex();

        questionTxt.text = GameData.instance.getQuestionArray()[questionIndex];

        for (int i = 0; i < answerTxtGO.Length; i++)
        {
            answerTxtGO[i].GetComponent<Text>().text = GameData.instance.getAnswerArray()[questionIndex, i];
        }
    }
}