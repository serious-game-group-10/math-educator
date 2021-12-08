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
        if (enemy == null)
        {
            enemy = GameObject.Find("Enemy");
        }
        transform.position = startPosition.transform.position + new Vector3(0.8f, 0.55f, -5);
        PlayerPrefs.SetInt("Fight", 0);
    }
    
    private void Update()
    {
        if (player.position.x > fightPosition.position.x && enemy != null) // boss scene
        {
            inFight = true;
            PlayerPrefs.SetInt("Fight", 1);
            transform.position = fightPosition.position + new Vector3(0.8f, 0.55f, -5);
        }
        else if (inFight)
        {
            if (enemy == null)
            {
                PlayerPrefs.SetInt("Fight", 0);
                inFight = false;
            }
            transform.position = fightPosition.position + new Vector3(0.8f, 0.55f, -5);
        }
        else if (player.position.x > endPosition.position.x) // exit scene
        {
            transform.position = endPosition.transform.position + new Vector3(0.8f, 0.55f, -5);
        }
        else if (player.transform.position.x > startPosition.position.x && player.position.x < endPosition.position.x) // enter scene
        {
            transform.position = player.transform.position + new Vector3(0.8f, 0.55f, -5);
        }
    }


}
