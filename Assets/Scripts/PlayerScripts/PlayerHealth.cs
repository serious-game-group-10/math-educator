using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider healthBar;

    private void Start()
    {
        if (healthBar == null)
        {
            healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        }

        defaultHealth();
    }

    public void UpdateHealth(int currentHealth)
    {
        healthBar.value = currentHealth;
    }

    private void defaultHealth()
    {
        healthBar.value = 100;
    }
}
