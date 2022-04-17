using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ObjectSpawner : SingletonPun<ObjectSpawner>
{
    [SerializeField] private List<Vector3> spawnPositions;

    private void Awake()
    {
        StartCoroutine(SpawnObjects());
    }

    private void SpawnPlayer(bool isMasterClient)
    {
        if (isMasterClient)
        {
            PhotonNetwork.Instantiate("Player", spawnPositions[0], Quaternion.identity);
            return;
        }

        var go = PhotonNetwork.Instantiate("Player", spawnPositions[1], Quaternion.identity);
        var temp = go.transform.localScale;
        temp.x = -temp.x;
        go.transform.localScale = temp;
    }

    private IEnumerator SpawnObjects()
    {
        yield return new WaitUntil(() => PhotonNetwork.PlayerList.Length == 2);
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
        PhotonNetwork.Instantiate("Ball", new Vector3(0f, 15f, 0f), Quaternion.identity);
    }
}