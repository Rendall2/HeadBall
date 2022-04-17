using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.attachedRigidbody) return;
        if (other.attachedRigidbody.TryGetComponent(out Ball ball))
        {
            if (PhotonNetwork.IsMasterClient) ball.ResetPosition();
        }
    }
}
