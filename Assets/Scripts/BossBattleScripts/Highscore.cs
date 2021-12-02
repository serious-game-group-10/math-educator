using System;
public class Highscore
{
    private string playerName;
    private int currentScore;

    public Highscore()
    {
    }

    public Highscore(string playerName, int currentScore)
    {
        this.playerName = playerName;
        this.currentScore = currentScore;
    }

    public string getPlayerName()
    {
        return playerName;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }
}
