using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private Text healthText;

    private void Start()
    {
        healthText = GameObject.Find("EnemyHealthTxt").GetComponent<Text>();
        defaultHealth();
    }

    public void updateHealth(int currentHealth)
    {
        healthText.text = "Health: " + currentHealth;
    }

    private void defaultHealth()
    {
        healthText.text = "Enemy: " + 100;
    }
}