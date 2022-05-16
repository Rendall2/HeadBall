using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireUp : MonoBehaviour
{
    public bool PlayerIsOnfire { get; set; }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.rigidbody && collisionInfo.rigidbody.TryGetComponent(out Ball ball) && PlayerIsOnfire)
        {
            ball.rb.AddForce((PlayerManager.Instance.mainPlayer.playerGoalPost.transform.position + Vector3.up * 3 - ball.transform.position) * 8, ForceMode.VelocityChange);
        }
    }
}