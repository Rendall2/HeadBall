using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Photon.Pun;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public bool IsGrounded { get; set; }
    private float moveSpeed = 100;
    private float jumpPower = 10;
    private float horizontalSpeed;
    private float currentInput;

    private void Start()
    {
        if (!player.photonView.IsMine) Destroy(this);
    }
    
    void Update()
    {
        MovePlayer();
        AddGravitionalForce();
        if (Input.GetKeyDown(KeyCode.Space)) Kick();
    }

    private void MovePlayer()
    {
        HorizontalMovement();
        VerticalMovement();
    }

    private void VerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            player.rb.AddForce(transform.up * 20, ForceMode.Impulse);
        }
    }


    private void HorizontalMovement()
    {
        currentInput = Input.GetAxis("Horizontal");
        if (currentInput > 0) horizontalSpeed = 10;
        else if (currentInput < 0) horizontalSpeed = -10;
        else horizontalSpeed = 0;
        
        Vector3 temp = player.rb.velocity;
        temp.x = horizontalSpeed;
        player.rb.velocity = temp;
    }

    private void AddGravitionalForce()
    {
        float gravitionalForce = UsefulFunctions.Map(transform.position.y, 1, 5, 0, 30);
        player.rb.AddForce(-transform.up * gravitionalForce);
    }

    private void Kick()
    {
        
    }
}