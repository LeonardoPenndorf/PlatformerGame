using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpHeight;
    public Rigidbody2D rb;
    public bool isGrounded;
    public float x;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            Jump();
        }

        anim.SetBool("isRunning", x != 0);

    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(x * playerSpeed, rb.velocity.y);

        if (rb.velocity.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (rb.velocity.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            anim.SetBool("isGrounded", isGrounded);

        }
    }
}
