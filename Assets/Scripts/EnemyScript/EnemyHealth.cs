using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Slider healthBar;

    private void Start()
    {
        if (healthBar == null)
        {
            healthBar = GameObject.Find("EnemyHealthBar").GetComponent<Slider>();
        }

        defaultHealth();
    }

    public void updateHealth(int currentHealth)
    {
        healthBar.value = currentHealth;
    }

    private void defaultHealth()
    {
        healthBar.value = 100;
    }
}