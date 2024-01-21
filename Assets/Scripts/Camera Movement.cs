using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float cameraSpeed;
    public float speed = 0; // becomes equal to cameraSpeed when the game starts

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
    }
}
