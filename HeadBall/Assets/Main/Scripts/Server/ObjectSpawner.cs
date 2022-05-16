using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ObjectSpawner : SingletonPun<ObjectSpawner>
{
    [SerializeField] private List<Vector3> spawnPositions;
    private Transform owner;
    private Ball ball;
    private Vector3 ballDefaultPos = new Vector3(0f, 15f, 0f);

    private void Awake()
    {
        SpawnObjects();
    }

    private void SpawnPlayer(bool isMasterClient)
    {
        if (isMasterClient)
        {
            SpawnMasterPlayer();
            return;
        }

        SpawnOtherPlayer();
    }

    private void SpawnMasterPlayer()
    {
        var player1 = PhotonNetwork.Instantiate("Player", spawnPositions[0], Quaternion.identity);
        owner = player1.transform;
        Player player = player1.GetComponent<Player>();
        player.playerGoalPost = GoalPosts.Instance.rightGoalPost;
        player.enemyGoalPost = GoalPosts.Instance.leftGoalPost;
        PlayerManager.Instance.mainPlayer = player;
    }

    private void SpawnOtherPlayer()
    {
        var player2 = PhotonNetwork.Instantiate("Player", spawnPositions[1], Quaternion.identity);
        owner = player2.transform;
        var temp = player2.transform.localScale;
        temp.x = -temp.x;
        player2.transform.localScale = temp;
        Player player = player2.GetComponent<Player>();
        player.playerGoalPost = GoalPosts.Instance.leftGoalPost;
        player.enemyGoalPost = GoalPosts.Instance.rightGoalPost;
    }

    private void SpawnObjects()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnBall();
            SpawnPlayer(true);
        }
        else
        {
            SpawnPlayer(false);
        }
    }

    private void SpawnBall()
    {
        ball = PhotonNetwork.Instantiate("Ball", ballDefaultPos, Quaternion.identity).GetComponent<Ball>();
    }

    public void ResetPositions()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            owner.position = spawnPositions[0];
            ResetBall();
            return;
        }
        owner.position = spawnPositions[1];
    }

    private void ResetBall()
    {
        ball.transform.position = ballDefaultPos;
        ball.rb.velocity = Vector3.zero;
        ball.rb.angularVelocity = Vector3.zero;
    }
}