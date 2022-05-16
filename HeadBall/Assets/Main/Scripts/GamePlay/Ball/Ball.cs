using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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

    [PunRPC]
    public void InitBallFire(float duration)
    {
        StartCoroutine(OpenBallFire(duration));
    }

    private IEnumerator OpenBallFire(float duration)
    {
        fireObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        fireObject.SetActive(false);
    }

    public void Shoot(Vector3 dir)
    {
        dir.y = 0f;
        rb.AddForce((dir + Vector3.up * .8f) * shootPower,ForceMode.Impulse);
    }
}
