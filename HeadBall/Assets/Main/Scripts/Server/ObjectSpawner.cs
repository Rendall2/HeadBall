using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ObjectSpawner : SingletonPun<ObjectSpawner>
{
    private void Awake()
    {
        SpawnPlayer();
        if (Equals(PhotonNetwork.PlayerList[1], PhotonNetwork.LocalPlayer))
        {
            Debug.Log("entered");
            SpawnBall();
        }
    }

    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }

    private void SpawnBall()
    {
        PhotonNetwork.Instantiate("Ball", new Vector3(7.5f,15f,0f), Quaternion.identity);
    }

}
