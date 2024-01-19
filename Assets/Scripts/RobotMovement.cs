using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed;
    public float x;
    public float minX, maxX;
    public Rigidbody2D rb;


    private void Start()
    {
        x = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x < minX)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            x = speed;
        } else if (transform.localPosition.x > maxX)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            x = -speed;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x, 0);
    }
}
