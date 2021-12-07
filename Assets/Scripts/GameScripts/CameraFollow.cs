using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform startPosition;
    [SerializeField] Transform endPosition;

    private void Start()
    {
        transform.position = startPosition.transform.position + new Vector3(0.8f, 0.55f, -5);
    }
    
    private void Update()
    {
        if (player.transform.position.x > startPosition.position.x && player.position.x < endPosition.position.x)
        {
            transform.position = player.transform.position + new Vector3(0.8f, 0.55f, -5);
        }
        else if (player.position.x > endPosition.position.x)
        {
            transform.position = endPosition.transform.position + new Vector3(0.8f, 0.55f, -5);
        }
    }


}
