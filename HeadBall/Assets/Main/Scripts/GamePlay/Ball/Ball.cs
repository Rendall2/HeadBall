using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Ball : SingletonPun<Ball>
{
    public Rigidbody rb;
    public PhotonView photonView;
    public float shootPower { get; set; }=  16;
    public float fireShootPower { get; set; }=  30;
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

    [PunRPC]
    public void Shoot(Vector3 dir)
    {
        if (isOnFire) return;
        rb.AddForce((dir + Vector3.up * .7f) * shootPower,ForceMode.Impulse);
    }    
    
    [PunRPC]
    public void ShootFireBall()
    {
        rb.AddForce((PlayerManager.Instance.mainPlayer.playerGoalPost.transform.position + Vector3.up * 2 - transform.position).magnitude * Vector3.one * fireShootPower, ForceMode.VelocityChange);
    }
}
