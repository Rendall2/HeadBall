using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireUp : MonoBehaviour
{
    public bool PlayerIsOnfire { get; set; }
    public bool isOnCd;

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (isOnCd) return;
        if (!PlayerIsOnfire) return;
        
        if (collisionInfo.rigidbody && collisionInfo.rigidbody.TryGetComponent(out Ball ball))
        {
            ball.rb.AddForce((PlayerManager.Instance.mainPlayer.playerGoalPost.transform.position + Vector3.up * 3 - ball.transform.position) * 8, ForceMode.VelocityChange);
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