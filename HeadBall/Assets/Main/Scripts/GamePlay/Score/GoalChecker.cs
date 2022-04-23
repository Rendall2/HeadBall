using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
    [SerializeField] private GoalPost goalPost;
    private bool canTrigger = true;
    private void OnTriggerEnter(Collider other)
    {
        if(!canTrigger) return;
        if(!other.attachedRigidbody) return;
        if (!other.attachedRigidbody.TryGetComponent(out Ball ball)) return;
        StartCoroutine(DoGoalActions());
        canTrigger = false;
    }

    private IEnumerator DoGoalActions()
    {
        goalPost.UpdatePlayerScore();
        yield return StartCoroutine(InGameUI.Instance.ChangeActiveGoalText());
        ObjectSpawner.Instance.ResetPositions();
        canTrigger = true;
    }
    
}
