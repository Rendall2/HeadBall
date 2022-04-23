using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KickControl : MonoBehaviour
{
    private Ball ball;
    private Coroutine shootCoroutine;
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
        if(shootCoroutine != null) StopCoroutine(shootCoroutine);
        shootCoroutine = StartCoroutine(TryShoot());
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

    private IEnumerator TryShoot()
    {
        while (canTryKick)
        {
            Debug.Log("try shoot");
            if (isContactedWithBall)
            {
                var dir = transform.right;
                ball.Shoot(dir);
                break;
            }
            yield return null;
        }
    }
}
