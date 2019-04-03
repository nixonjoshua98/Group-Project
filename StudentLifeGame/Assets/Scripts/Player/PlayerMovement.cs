using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /* - - - - INSPECTOR PRIVATES - - - - */
    public float speedMultiplier;
    public float jumpMultiplier;
    public float jumpForce;
    public float cooldown;


    /* - - - - COMPONENTS - - - - */
    public Rigidbody2D rb;
    public Animator anim;


    /* - - - - PRIVATES - - - - */
    private float jumpTimer = 0.0f;
    private bool playerCanJump = false;
    private bool currentlyJumping = false;


    /* - - - - PUBLIC ACCESSORS - - - - */
    public bool isHoldingJump { get { return Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W); } }


    private void Update()
    {
        jumpTimer += Time.deltaTime;

        if (jumpTimer >= cooldown)
            playerCanJump = true;


        if (isHoldingJump && !currentlyJumping)
            Jump();

        Move();

    }


    private void Move()
    {
        rb.velocity = new Vector2(Vector2.right.x * speedMultiplier, rb.velocity.y);
    }


    private void Jump()
    {
        jumpTimer = 0.0f;
        currentlyJumping = true;
        playerCanJump = false;


        rb.velocity = Vector2.up * jumpForce;


        Debug.Log("Player jumped");
    }


    private void UpdatePosition()
    {
        if (currentlyJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tile"))
        {
            currentlyJumping = false;
        }
    }
}
