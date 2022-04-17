using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.rigidbody) return;
        if (other.rigidbody.TryGetComponent(out Player player))
        {
            player.playerMovement.IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(!other.rigidbody) return;
        if (other.rigidbody.TryGetComponent(out Player player))
        {
            player.playerMovement.IsGrounded = false;
        }
    }
}
