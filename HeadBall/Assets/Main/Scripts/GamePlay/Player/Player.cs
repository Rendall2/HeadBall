using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Rigidbody rb;
    public PhotonView photonView;
    public GoalPost playerGoalPost;
    public GoalPost enemyGoalPost;

    #region MyRegion

    private void OnEnable()
    {
        LevelConditions.OnGameEnds += CheckGameState;
    }

    private void OnDisable()
    {
        LevelConditions.OnGameEnds -= CheckGameState;
    }

    private void CheckGameState()
    {
        if (playerGoalPost.playerScore > enemyGoalPost.playerScore)
        {
            InGameUI.Instance.SuccessGame();
            return;
        }

        if (playerGoalPost.playerScore < enemyGoalPost.playerScore)
        {
            InGameUI.Instance.FailGame();
            return;
        }
        
        //Draw senaryosu var.
    }

    #endregion gameStates
}
