using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 startPos = new Vector3(0, 15, 0);
    public IEnumerator ResetPosition()
    {
        yield return new WaitUntil(() => rb.velocity.sqrMagnitude < 2f);
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }
}
