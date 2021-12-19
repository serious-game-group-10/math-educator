using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingShipMove : MonoBehaviour
{
    GameObject target;
    Rigidbody2D ship;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Target");
        }

        if (ship == null)
        {
            ship = GameObject.Find("Ship").GetComponent<Rigidbody2D>();
        }

        ShipMovement();
    }

    private void ShipMovement()
    {
        Vector2 force = (target.transform.position - transform.position).normalized * 0.1f;
        ship.velocity = new Vector2(force.x, force.y);
    }
}
