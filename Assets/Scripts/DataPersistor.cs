using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistor : MonoBehaviour
{
    private float gameVolume;
    private bool inFight;

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
        }
    }

    private void Start()
    {
        gameVolume = 0.5f;
        inFight = false;
    }

    public void setGameVolume(float gameVolume)
    {
        this.gameVolume = gameVolume;
    }

    public void setInFight(bool inFight)
    {
        this.inFight = inFight;
    }

    public bool getInFight()
    {
        return inFight;
    }

    public float getGameVolume()
    {
        return gameVolume;
    }
}
