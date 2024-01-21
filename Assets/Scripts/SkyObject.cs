using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyObject : MonoBehaviour
{
    public Transform boundary;
    public bool isTravelingRight;
    public Rigidbody2D rb;
    public float velocity;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocity, 0);

        if (isTravelingRight && (transform.position.x > boundary.position.x))
        {
            Destroy(gameObject);
        }
        else if (!isTravelingRight && (transform.position.x < boundary.position.x))
        {
            Destroy(gameObject);
        }
    }
}
