using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Singleton<Ball>
{
    public Rigidbody rb;
    public float shootPower = 100f;
    public bool isOnFire;
    public GameObject fireObject;

    private void Awake()
    {
        fireObject.SetActive(false);
    }

    public IEnumerator OpenBallFire(float duration)
    {
        fireObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        fireObject.SetActive(false);
    }

    public void Shoot(Vector3 dir)
    {
        rb.AddForce((dir + Vector3.up) * shootPower,ForceMode.Impulse);
    }

    public IEnumerator MakeBallInFire(float duration)
    {
        isOnFire = true;
        yield return new WaitForSeconds(duration);
        isOnFire = false;
    }
}
