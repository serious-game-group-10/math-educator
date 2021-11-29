using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private const int BULLET_DAMAGE = 10;
    private const float BULLET_SPEED = 5f;
    private GameObject enemy;
    private Rigidbody2D playerBullet;
    private GameObject UIDisplay;
    private UIBoss UIBoss;

    void Start()
    {
        playerBullet = gameObject.GetComponent<Rigidbody2D>();
        enemy = GameObject.Find("Boss");
        UIDisplay = GameObject.Find("UIDisplay");
        UIBoss = UIDisplay.GetComponent<UIBoss>();
    }

    void Update()
    {
        playerBullet.velocity = enemy.transform.position * BULLET_SPEED;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            enemy.GetComponent<Enemy>().takeDamage(BULLET_DAMAGE);
            UIBoss.enableUI();
            UIBoss.displayQuestionAndAnswer();
            Destroy(gameObject);
        }
    }
}