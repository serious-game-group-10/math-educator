﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private const int BULLET_DAMAGE = 20;
    private const float BULLET_SPEED = 2f;
    private GameObject player;
    private Rigidbody2D enemyBullet;

    void Start()
    {
        player = GameObject.Find("Player");
        enemyBullet = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        enemyBullet.velocity = player.transform.position * BULLET_SPEED;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().takeDamage(BULLET_DAMAGE);
            Destroy(gameObject);
        }
    }
}