using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    [SerializeField] private Text highScoreOne;
    [SerializeField] private Text highScoreNameOne;
    [SerializeField] private Text highScoreTwo;
    [SerializeField] private Text highScoreNameTwo;
    [SerializeField] private Text highScoreThree;
    [SerializeField] private Text highScoreNameThree;
    [SerializeField] private Text highScoreFour;
    [SerializeField] private Text highScoreNameFour;
    [SerializeField] private Text highScoreFive;
    [SerializeField] private Text highScoreNameFive;

    void Start()
    {
        highScoreOne = GameObject.Find("HighScore1").GetComponent<Text>();
        highScoreTwo = GameObject.Find("HighScore2").GetComponent<Text>();
        highScoreThree = GameObject.Find("HighScore3").GetComponent<Text>();
        highScoreFour = GameObject.Find("HighScore4").GetComponent<Text>();
        highScoreFive = GameObject.Find("HighScore5").GetComponent<Text>();
        highScoreNameOne = GameObject.Find("HighScoreName1").GetComponent<Text>();
        highScoreNameTwo = GameObject.Find("HighScoreName2").GetComponent<Text>();
        highScoreNameThree = GameObject.Find("HighScoreName3").GetComponent<Text>();
        highScoreNameFour = GameObject.Find("HighScoreName4").GetComponent<Text>();
        highScoreNameFive = GameObject.Find("HighScoreName5").GetComponent<Text>();

        //displayOne();
        //displayTwo();
        //displayThree();
        //displayThree();
        //displayFour();
        //displayFive();
    }

    public void displayOne()
    {
        if (DataPersistor.instance.getHighscoreDB()[0] == null)
        {

        }
        else
        {
            highScoreNameOne.text = DataPersistor.instance.getHighscoreDB()[0].getPlayerName();
            highScoreOne.text = DataPersistor.instance.getHighscoreDB()[0].getCurrentScore().ToString();
        }
    }

    public void displayTwo()
    {
        if (DataPersistor.instance.getHighscoreDB()[1] == null)
        {

        }
        else
        {
            highScoreNameTwo.text = DataPersistor.instance.getHighscoreDB()[1].getPlayerName();
            highScoreTwo.text = DataPersistor.instance.getHighscoreDB()[1].getCurrentScore().ToString();
        }
    }

    public void displayThree()
    {
        if (DataPersistor.instance.getHighscoreDB()[2] == null)
        {

        }
        else
        {
            highScoreNameThree.text = DataPersistor.instance.getHighscoreDB()[2].getPlayerName();
            highScoreThree.text = DataPersistor.instance.getHighscoreDB()[2].getCurrentScore().ToString();
        }
    }

    public void displayFour()
    {
        if (DataPersistor.instance.getHighscoreDB()[3] == null)
        {

        }
        else
        {
            highScoreNameFour.text = DataPersistor.instance.getHighscoreDB()[3].getPlayerName();
            highScoreFour.text = DataPersistor.instance.getHighscoreDB()[3].getCurrentScore().ToString();
        }
    }

    public void displayFive()
    {
        if (DataPersistor.instance.getHighscoreDB()[4] == null)
        {

        }
        else
        {
            highScoreNameFive.text = DataPersistor.instance.getHighscoreDB()[4].getPlayerName();
            highScoreFive.text = DataPersistor.instance.getHighscoreDB()[4].getCurrentScore().ToString();
        }
    }
}
