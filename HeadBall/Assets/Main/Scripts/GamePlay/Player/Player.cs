using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GoalPost playerGoalPost { get; set; }
    public GoalPost enemyGoalPost { get; set; }
    public GameObject ice;
    public PlayerMovement playerMovement;
    public KickControl kickControll;
    public PlayerFireUp playerFireUp;
    public Rigidbody rb;
    public PhotonView photonView;

    private void Awake()
    {
        ice.gameObject.SetActive(false);
        LevelConditions.OnGameEnds += CheckGameState;
    }

    [PunRPC]
    private void FreezeOtherPlayer()
    {
        StartCoroutine(FreezeYourself());
    }

    IEnumerator FreezeYourself()
    {
        if (playerMovement) playerMovement.enabled = false;
        ice.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        ice.gameObject.SetActive(false);
        if (playerMovement) playerMovement.enabled = true;
    }

    #region MyRegion
    

    private void CheckGameState()
    {
        Debug.Log(playerGoalPost.playerScore);
        Debug.Log(enemyGoalPost.playerScore);
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