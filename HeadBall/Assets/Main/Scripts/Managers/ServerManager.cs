using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerManager : SingletonPun<ServerManager>
{
    private const float SceneChangeDelay = .5f;
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
        SceneManager.LoadScene(1);
    }

    public bool CreateRoom(string roomName)
    {
        if (roomName == "") return false;
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 2
        };
        return  PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    public bool JoinRoom(string roomName)
    {
        if (roomName == "") return false;
        var isOperationCompleted = PhotonNetwork.JoinRoom(roomName);
        if (isOperationCompleted) SceneManager.LoadScene(1);
        return PhotonNetwork.JoinRoom(roomName);
    }

    public bool JoinRandomRoom()
    {
        var isOperationCompleted = PhotonNetwork.JoinRandomRoom();
        if (isOperationCompleted) SceneManager.LoadScene(1);
        return PhotonNetwork.JoinRandomRoom();
    }
}
