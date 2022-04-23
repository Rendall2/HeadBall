using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : SingletonPun<Ball>
{
    public Rigidbody rb;
    public float shootPower = 30f;

    public void Shoot(Vector3 dir)
    {
        rb.AddForce(dir * shootPower,ForceMode.Impulse);
    }
}
