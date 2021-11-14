using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private const int BULLET_DAMAGE = 25;
    private const float BULLET_SPEED = 5f;
    private GameObject enemy;
    private Rigidbody2D playerBullet;
    private GameObject questionPanel;
    private DisplayQuestion questionDisplayer;

    void Start()
    {
        playerBullet = gameObject.GetComponent<Rigidbody2D>();
        enemy = GameObject.Find("Boss");

        questionPanel = GameObject.Find("QuestionPanel");
        questionDisplayer = questionPanel.GetComponent<DisplayQuestion>();
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
            questionDisplayer.displayQuestionAndAnswer();
            Destroy(gameObject);
        }
    }
}