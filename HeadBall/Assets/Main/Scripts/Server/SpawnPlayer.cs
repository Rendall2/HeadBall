using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SpawnPlayer : SingletonPun<SpawnPlayer>
{
    [SerializeField] private GameObject player;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }
    
    
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("asdf", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        SpawnAPlayer();
    }


    private void SpawnAPlayer()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }
    
    
}
