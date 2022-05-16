using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Ball : SingletonPun<Ball>
{
    public Rigidbody rb;
    public float shootPower { get; set; }= 22;
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
    
    public IEnumerator OpenBallFire(float duration)
    {
        fireObject.SetActive(true);
        isOnFire = true;
        yield return new WaitForSeconds(duration);
        fireObject.SetActive(false);
        isOnFire = false;
    }

    public void Shoot(Vector3 dir)
    {
        if (isOnFire) return;
        rb.AddForce((dir + Vector3.up) * shootPower,ForceMode.Impulse);
    }
}
