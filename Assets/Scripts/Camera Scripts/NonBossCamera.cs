using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonBossCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform startPosition;
    [SerializeField] Transform endPosition;

    private void Start()
    {
        startPosition = GameObject.Find("StartPosition").transform;
        endPosition = GameObject.Find("EndPosition").transform;
        transform.position = startPosition.position + new Vector3(0.8f, 0.55f, -5);
    }

    private void Update()
    {
        if (player.transform.position.x > endPosition.position.x) // exit scene
        {
            transform.position = endPosition.position + new Vector3(0.8f, 0.55f, -5); // camera does not move
        }
        else if (player.transform.position.x > startPosition.position.x && player.transform.position.x < endPosition.position.x) // camera follow player
        {
            transform.position = player.transform.position + new Vector3(0.8f, 0.55f, -5);
        }
        else if (player.transform.position.x < startPosition.position.x)
        {
            transform.position = startPosition.position + new Vector3(0.8f, 0.55f, -5);
        }
    }
}
