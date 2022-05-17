using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerFireUp : MonoBehaviour
{
    public bool PlayerIsOnfire { get; set; }
    public bool isOnCd;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (isOnCd) return;
        if (!PlayerIsOnfire) return;
        Debug.Log("shoot!!");
        
        if (collisionInfo.rigidbody && collisionInfo.rigidbody.TryGetComponent(out Ball ball))
        {
            ball.photonView.RPC("ShootFireBall", RpcTarget.All);
            StartCoroutine(CdCoroutine());
        }
    }
    

    IEnumerator CdCoroutine()
    {
        isOnCd = true;
        yield return new WaitForSeconds(1);
        isOnCd = false;
    }
}