using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float shootPower = 100f;

    public void Shoot(Vector3 dir)
    {
        Debug.Log("shoot");
        rb.AddForce((dir + Vector3.up * 2f) * shootPower,ForceMode.Impulse);
    }
}
