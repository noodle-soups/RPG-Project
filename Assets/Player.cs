using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    private Animator anim;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float xInput;

    [Header("Dash")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;

    [Header("Flip Sprite")]
    private int facingDir = 1;
    private bool facingRight = true;

    [Header("Collision")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        Movement();
        CheckInput();

        dashTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            dashTime = dashDuration;
        }

        if (dashTime > 0)
        {
            Debug.Log("I am dashing");
        }

        CollisionChecks();
        FlipController();
        AnimatorControllers();
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Movement()
    {
        if (dashTime > 0)
        {
            rb.velocity = new Vector2(xInput * dashSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        }

    }

    private void Jump()
    {
        if (isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void AnimatorControllers()
    {
        bool isMoving = rb.velocity.x != 0;
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isMoving", isMoving);
        // raycast determines value of isGrounded
        anim.SetBool("isGrounded", isGrounded);
    }

    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if (rb.velocity.x > 0 && !facingRight)
            Flip();
        else if (rb.velocity.x < 0 && facingRight)
            Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }



}
