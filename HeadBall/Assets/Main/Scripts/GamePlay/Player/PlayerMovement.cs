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

    private void Start()
    {
        if (!photonView.IsMine) Destroy(this);
    }

    // Update is called once per frame
    void Update()
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
        
    }

    private float currentInput, oldInput;
    
    void HorizontalMovement()
    {
        float currentInput = Input.GetAxis("Horizontal");
        float speed = Mathf.Lerp(0, 10, currentInput);
        rb.velocity = speed * Vector3.right;
    }

    void ClampSpeed()
    {
       // Input.GetAxis("Horizontal")
    }

}
