using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerFireUp : MonoBehaviour
{
    public bool PlayerIsOnfire { get; set; }
    public bool isOnCd;

    private void OnTriggerEnter(Collider other)
    {
        if (isOnCd) return;
        if (!PlayerIsOnfire) return;

        if (other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out Ball ball))
        {
            Vector3 dir = (PlayerManager.Instance.mainPlayer.playerGoalPost.transform.position + Vector3.up * 1.5f - ball.transform.position)
                .normalized;
            ball.photonView.RPC("ShootFireBall", RpcTarget.All, dir);

            

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