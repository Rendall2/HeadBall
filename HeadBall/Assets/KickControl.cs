using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Photon.Pun;
using UnityEngine;

public class KickControl : MonoBehaviour
{
    private bool isContactedWithBall = false;
    private bool canTryKick;

    private void Start()
    {
        if (PlayerManager.Instance.enemyPlayer.kickControll == this) Destroy(this);
    }

    public void KickSimulate()
    {
        canTryKick = true;
        DOTween.Complete("kickTween");
        if (PhotonNetwork.IsMasterClient)
        {
            transform.DORotate(transform.forward * 20f, .1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).OnKill(() =>
            {
                transform.eulerAngles = Vector3.zero;
                canTryKick = false;
            }).SetId("kickTween");
        }
        else
        {
            transform.DORotate(-transform.forward * 20f, .1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).OnKill(() =>
            {
                transform.eulerAngles = Vector3.zero;
                canTryKick = false;
            }).SetId("kickTween"); 
        }

    }

    private void OnCollisionStay(Collision other)
    {
        if (!other.rigidbody) return;
        if (!other.rigidbody.TryGetComponent(out Ball ball)) return;
        if (canTryKick)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                ball.Shoot(Vector3.right);
                
            }
            else
            {
                ball.Shoot(Vector3.left);

            }
            canTryKick = false;
        }
    }
}
