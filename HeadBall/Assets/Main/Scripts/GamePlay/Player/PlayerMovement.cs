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
        AddGravitionalForce();
    }

    void MovePlayer()
    {
        HorizontalMovement();
        VerticalMovement();
    }

    void VerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 15, ForceMode.Impulse);
        }
    }

    
    void HorizontalMovement()
    {
        currentInput = Input.GetAxis("Horizontal");
        horizontalSpeed = Mathf.LerpUnclamped(0, 10, currentInput);
        Vector3 temp = rb.velocity;
        temp.x = horizontalSpeed;
        rb.velocity = temp;    }

    void AddGravitionalForce()
    {
        float gravitionalForce = UsefulFunctions.Map(transform.position.y, 1, 5, 0, 30);
        rb.AddForce(-transform.up * gravitionalForce);
    }

}
