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
    private float jumpPower = 60f;
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
        Debug.Log("right: " + willMoveTowardsRight);
        Debug.Log("left: " + willMoveTowardsLeft);
        if (willMoveTowardsRight)
        {
            temp.x += horizontalSpeed;
            willMoveTowardsRight = false;
        }

        else if (willMoveTowardsLeft)
        {
            temp.x -= horizontalSpeed;
            willMoveTowardsLeft = false;
        }
        else
        {
            temp.x = 0f;
        }
        player.rb.velocity = temp;
    }

    private void AddGravitionalForce()
    {
        if(IsGrounded) return;
        float gravitionalForce = UsefulFunctions.Map(transform.position.y, 1, 5, 0, 20);
        player.rb.AddForce(-transform.up * gravitionalForce);
    }

    private void Kick()
    {
    }
}