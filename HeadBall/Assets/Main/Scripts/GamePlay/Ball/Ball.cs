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
        Debug.Log("here");
        StartCoroutine(OpenBallFire(duration));
    }
    
    public IEnumerator OpenBallFire(float duration)
    {
        fireObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        fireObject.SetActive(false);
    }

    public void Shoot(Vector3 dir)
    {
        Debug.Log((dir + Vector3.up) * shootPower);
        rb.AddForce((dir + Vector3.up) * shootPower,ForceMode.Impulse);
    }
}
