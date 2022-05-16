using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GoalPost playerGoalPost { get; set; }
    public GoalPost enemyGoalPost { get; set; }
    public PlayerMovement playerMovement;
    public KickControl kickControll;
    public PlayerFireUp playerFireUp;
    public Rigidbody rb;
    public PhotonView photonView;

    
    [PunRPC]
    private void FreezeOtherPlayer()
    {
        StartCoroutine(FreezeYourself());
    }

    IEnumerator FreezeYourself()
    {
        playerMovement.enabled = false;
        yield return new WaitForSeconds(5);
        playerMovement.enabled = true;
    }
    
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
        
        InGameUI.Instance.DrawGame();
    }

    #endregion gameStates
}
