using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Entity
{

    [Header("Movement")]
    [SerializeField] private float moveSpeed; 

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
        if (!isGrounded || isWallDetected)
            Flip();
    }

}
