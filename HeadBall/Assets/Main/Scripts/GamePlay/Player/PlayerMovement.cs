using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Photon.Pun;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;
    [SerializeField] private Rigidbody rb;
    
    private float moveSpeed = 100;
    private float jumpPower = 10;
    private float horizontalSpeed;
    private float currentInput;

    private void Start()
    {
        if (!photonView.IsMine) Destroy(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        ClampSpeed();
    }

    void MovePlayer()
    {
        HorizontalMovement();
        VerticalMovement();
    }

    void VerticalMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("added force");
            rb.AddForce(transform.up * 100,ForceMode.Impulse);
        }
    }

    
    void HorizontalMovement()
    {
        currentInput = Input.GetAxis("Horizontal");
        horizontalSpeed = Mathf.LerpUnclamped(0, 10, currentInput);
        rb.velocity = horizontalSpeed * Vector3.right;
    }

    void ClampSpeed()
    {
       // Input.GetAxis("Horizontal")
    }

}
