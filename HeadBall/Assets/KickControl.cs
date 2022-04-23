using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KickControl : MonoBehaviour
{
    private Ball ball;
    private bool isContactedWithBall = false;
    private bool canTryKick;
    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    public void KickSimulate()
    {
        canTryKick = true;
        DOTween.Complete("kickTween");
        transform.DORotate(Vector3.forward * 20f, .1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).OnKill(() =>
        {
            transform.eulerAngles = Vector3.zero;
            canTryKick = false;
        }).SetId("kickTween");
    }

    private void OnCollisionStay(Collision other)
    {
        if(!other.rigidbody) return;
        if (!other.rigidbody.TryGetComponent(out Ball ball)) return;
        if (canTryKick)
        {
            ball.Shoot(transform.right);
            canTryKick = false;
        }
    }
}
