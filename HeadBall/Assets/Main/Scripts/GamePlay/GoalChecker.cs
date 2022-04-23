using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
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
        InGameUI.Instance.ChangeActiveGoalText(true);
        yield return new WaitForSeconds(.6f);
        InGameUI.Instance.ChangeActiveGoalText(false);
        yield return .4f;
        ObjectSpawner.Instance.ResetPositions();
        canTrigger = true;
    }
}
