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
    }

    void MovePlayer()
    {
        HorizontalMovement();
        VerticalMovement();
    }

    void VerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            player.rb.AddForce(transform.up * 20, ForceMode.Impulse);
        }
    }


    void HorizontalMovement()
    {
        currentInput = Input.GetAxis("Horizontal");
        horizontalSpeed = Mathf.LerpUnclamped(0, 10, currentInput);
        Vector3 temp = player.rb.velocity;
        temp.x = horizontalSpeed;
        player.rb.velocity = temp;
    }

    void AddGravitionalForce()
    {
        float gravitionalForce = UsefulFunctions.Map(transform.position.y, 1, 5, 0, 30);
        player.rb.AddForce(-transform.up * gravitionalForce);
    }
}