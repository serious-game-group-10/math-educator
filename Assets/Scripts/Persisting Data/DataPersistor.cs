using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistor : MonoBehaviour
{
    private float gameVolume;
    private bool inFight;
    private int currentScore;
    private string playerName;
    private Highscore[] highscoreDB;
    private int playerHealth;
    private int length;

    public static DataPersistor instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        gameVolume = 0.5f;
        inFight = false;
        currentScore = 0;
        playerHealth = 100;
        playerName = "Unkown Player";
        highscoreDB = new Highscore[5];
        length = 0;
    }

    public void setGameVolume(float gameVolume)
    {
        this.gameVolume = gameVolume;
    }

    public void setInFight(bool inFight)
    {
        this.inFight = inFight;
    }

    public void setPlayername(string playerName)
    {
        this.playerName = playerName;
    }

    public void setPlayerHealth(int playerHealth)
    {
        this.playerHealth = playerHealth;
    }

    public void addScore()
    {
        this.currentScore = this.currentScore + 1;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }

    public Highscore[] getHighscoreDB()
    {
        return highscoreDB;
    }

    public string getPlayerName()
    {
        return playerName;
    }

    public bool getInFight()
    {
        return inFight;
    }

    public float getGameVolume()
    {
        return gameVolume;
    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }

    public void gameReset()
    {
        this.playerName = "";
        this.currentScore = 0;
    }

    public void addHighScore()
    {
        for (int i = 0; i < highscoreDB.Length; i++)
        {
            if (highscoreDB[i] == null)
            {
                highscoreDB[i] = new Highscore(playerName, currentScore);
                this.length++;
                return;
            }
        }

        if (this.length != 0 || this.length != 1)
        {
            bubbleSort(highscoreDB);
        }
    }

    private void bubbleSort(Highscore[] highscore)
    {
        int n = this.length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (highscore[j].getCurrentScore() < highscore[j + 1].getCurrentScore())
                {
                    Highscore temp = highscore[j];
                    highscore[j] = highscore[j + 1];
                    highscore[j + 1] = temp;
                }
            }
        }
    }
}
