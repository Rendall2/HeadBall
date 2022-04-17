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
        SpawnPlayer(PhotonNetwork.IsMasterClient);
        if (!Equals(PhotonNetwork.PlayerList[0], PhotonNetwork.LocalPlayer)) return;
        SpawnBall();
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

    private void SpawnBall()
    {
        PhotonNetwork.Instantiate("Ball", new Vector3(7.5f,15f,0f), Quaternion.identity);
    }

}
