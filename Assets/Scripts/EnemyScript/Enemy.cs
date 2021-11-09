using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemy;
    [SerializeField] Text healthText;
    [SerializeField] int health = 20;

    // Start is called before the first frame update
    void Start()
    {   
        GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        GetHealth();
        if (health == 0)
        {
                Destroy(gameObject);
        }
    }

    //GetHealth
    private void GetHealth()
    {
        healthText.text = "Health: " + health;
    }

    //track collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "bullet(Clone)")
        {
        health -= 5;
        Debug.Log(health);
        }
    }

}