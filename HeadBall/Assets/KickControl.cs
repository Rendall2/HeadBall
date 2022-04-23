using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KickControl : MonoBehaviour
{
    private bool canTryKick;
    private bool isContactedWithBall = false;

    private void KickSimulate()
    {
        canTryKick = true;
        DOTween.Complete("kickTween");
        transform.DORotate(Vector3.forward * 15f, .25f).SetEase(Ease.InSine).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            canTryKick = false;
        }).SetId("kickTween");
    }

    private void OnCollisionEnter(Collision other)
    {
        if(!other.rigidbody) return;
        if (other.rigidbody.TryGetComponent(out Ball ball))
        {
            isContactedWithBall = true;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if(!other.rigidbody) return;
        if (other.rigidbody.TryGetComponent(out Ball ball))
        {
            isContactedWithBall = false;
        }
    }
}
