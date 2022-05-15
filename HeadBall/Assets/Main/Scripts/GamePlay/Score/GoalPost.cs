using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTmp;
    public int playerScore = 0;

    private void Awake()
    {
        scoreTmp.text = playerScore.ToString();
    }

    public void UpdatePlayerScore()
    {
        playerScore += 1;
        scoreTmp.text = playerScore.ToString();
    }
}
