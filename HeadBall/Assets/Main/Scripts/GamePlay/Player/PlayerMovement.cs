using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public bool IsGrounded { get; set; }
    private float moveSpeed = 100;
    private float jumpPower = 70f;
    private float horizontalSpeed = 15f;
    private bool willMoveTowardsRight = false;
    private bool willMoveTowardsLeft = false;
    private bool willJump = false;

    private void Start()
    {
        if (!player.photonView.IsMine) Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            willJump = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            willMoveTowardsLeft = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            willMoveTowardsRight = true;
        }
    }

    private void FixedUpdate()
    {
        VerticalMovement();
        HorizontalMovement();
        AddGravitionalForce();
    }

    private void VerticalMovement()
    {
        if (!willJump) return;
        player.rb.AddForce(transform.up * 20, ForceMode.Impulse);
        willJump = false;
    }


    private void HorizontalMovement()
    {
        var temp = player.rb.velocity;
        if(!willMoveTowardsRight && !willMoveTowardsLeft)
        {
            temp.x = 0f;
        }
        if (willMoveTowardsRight)
        {
            temp.x += horizontalSpeed;
            willMoveTowardsRight = false;
        }

        if (willMoveTowardsLeft)
        {
            temp.x -= horizontalSpeed;
            willMoveTowardsLeft = false;
        }
        player.rb.velocity = temp;
    }

    private void AddGravitionalForce()
    {
        if(IsGrounded) return;
        float gravitionalForce = UsefulFunctions.Map(transform.position.y, 1, 3, 0, 5);
        player.rb.AddForce(-transform.up * gravitionalForce);
    }

    private void Kick()
    {
    }
}