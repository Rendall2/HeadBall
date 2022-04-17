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

    public bool CreateRoom(string roomName)
    {
        if (roomName == "") return false;
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 2
        };
        return PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    public bool JoinRoom(string roomName)
    {
        if (roomName == "") return false;
        return PhotonNetwork.JoinRoom(roomName);
    }

    public bool JoinRandomRoom()
    {
        return PhotonNetwork.JoinRandomRoom();
    }
}
