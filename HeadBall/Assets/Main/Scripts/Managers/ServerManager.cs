using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ServerManager : SingletonPun<ServerManager>
{
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
        Debug.Log("Master Connected");
    }
    
    
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Someone Joined Lobby");

    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Someone Joined Room");

    }
}
