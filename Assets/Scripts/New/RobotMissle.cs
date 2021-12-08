using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMissle : MonoBehaviour
{
    private const int MISSLE_DAMAGE = 10;
    private const float MISSLE_SPEED = 0.3f;
    private GameObject player;
    private Rigidbody2D enemyMissle;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        
        if (enemyMissle == null)
        {
            enemyMissle = gameObject.GetComponent<Rigidbody2D>();
        }

        MissleMovement();
        Destroy(this.gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(MISSLE_DAMAGE);
            Debug.Log("Working");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }

    private void MissleMovement()
    {
        Vector2 force = (player.transform.position - transform.position).normalized * MISSLE_SPEED;
        enemyMissle.velocity = new Vector2(force.x, force.y);
    }
}
