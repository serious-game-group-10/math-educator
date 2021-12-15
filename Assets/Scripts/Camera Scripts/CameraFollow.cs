
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform fightPosition;
    [SerializeField] Transform startPosition;
    [SerializeField] Transform endPosition;
    [SerializeField] bool inFight = false;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        startPosition = GameObject.Find("StartPosition").transform;
        endPosition = GameObject.Find("EndPosition").transform;
        fightPosition = GameObject.Find("FightPosition").transform;
        transform.position = startPosition.position + new Vector3(0.8f, 0.55f, -5);
    }

    private void Update()
    {
        if (player.position.x > endPosition.position.x) // exit scene
        {
            transform.position = endPosition.position + new Vector3(0.8f, 0.55f, -5);
        }
        else if (player.position.x < startPosition.position.x)
        {
            transform.position = startPosition.position + new Vector3(0.8f, 0.55f, -5);
        }
        else if (player.position.x >= fightPosition.position.x && enemy != null)
        {
            transform.position = fightPosition.position + new Vector3(0.8f, 0.55f, -5);
            DataPersistor.instance.setInFight(true);
            Debug.Log(DataPersistor.instance.getInFight());
        }
        else if (player.position.x > startPosition.position.x && player.position.x < fightPosition.position.x ||
            player.position.x > fightPosition.position.x && player.position.x < endPosition.position.x) 
        {
            transform.position = player.position + new Vector3(0.8f, 0.55f, -5);
        }
        
    }
}
