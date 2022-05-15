using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float shootPower = 100f;

    public void Shoot(Vector3 dir)
    {
        rb.AddForce((dir + Vector3.up) * shootPower,ForceMode.Impulse);
    }
}
