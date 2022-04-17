using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 startPos = new Vector3(0, 15, 0);
    public void ResetPosition()
    {
        transform.position = startPos;
        Debug.Log("entered");
    }
}
