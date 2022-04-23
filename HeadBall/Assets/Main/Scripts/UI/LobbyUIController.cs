using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIController : SingletonPun<LobbyUIController>
{
    [SerializeField] private Button createButton;
    [SerializeField] private Button joinButton;
    [SerializeField] private Button findRandomMatchButton;
    [SerializeField] private TMP_InputField roomNameForCreating;
    [SerializeField] private TMP_InputField roomNameForJoining;
    
    private void Awake()
    {
        ListenButtons();
    }

    private void ListenButtons()
    {
        createButton.onClick.AddListener(() =>
        {
            var isOperationCompleted = ServerManager.Instance.CreateRoom(roomNameForCreating.text);
            ButtonVisualFeedback(createButton.transform, isOperationCompleted);
        });
        joinButton.onClick.AddListener(() =>
        {
            var isOperationCompleted = ServerManager.Instance.JoinRoom(roomNameForJoining.text);
            ButtonVisualFeedback(joinButton.transform,isOperationCompleted);
        });
        findRandomMatchButton.onClick.AddListener(() =>
        {
            var isOperationCompleted = ServerManager.Instance.JoinRandomRoom();
            ButtonVisualFeedback(findRandomMatchButton.transform,isOperationCompleted);
        });
    }

    private void ButtonVisualFeedback(Transform button, bool isOperationCompleted)
    {
        switch (isOperationCompleted)
        {
            case true:
                UIManager.Instance.OpenLoadingUI();
                Debug.Log("Operation Completed");
                break;
            case false:
                Debug.Log("Operation Failed");
                break;
        }
    }
    
}