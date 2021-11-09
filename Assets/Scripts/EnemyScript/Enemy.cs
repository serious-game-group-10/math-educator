using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    private int health;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        health = 100;
    }


    public void takeDamage(int damagePoint)
    {
        health -= damagePoint;

        enemyHealth.updateHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("EndScene");
    }

}
