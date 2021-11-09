using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GameObject.Find("PlayerHealthTxt").GetComponent<Text>();
        defaultHealth();
    }

    public void updateHealth(int currentHealth)
    {
        text.text = "Health: " + currentHealth;
    }

    private void defaultHealth()
    {
        text.text = "Player: " + 100;
    }
}
