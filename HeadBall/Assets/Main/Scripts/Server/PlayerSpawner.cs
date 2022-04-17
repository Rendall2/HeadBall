using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerSpawner : SingletonPun<PlayerSpawner>
{
    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }

}
