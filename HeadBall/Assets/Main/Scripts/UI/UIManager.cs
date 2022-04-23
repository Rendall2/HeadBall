using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonPun<UIManager>
{
    [SerializeField] private LoadingUIController loadingUIController;
    [SerializeField] private LobbyUIController lobbyUIController;

    private void Awake()
    {
        loadingUIController.gameObject.SetActive(false);
    }

    public void OpenLoadingUI()
    {
        loadingUIController.gameObject.SetActive(true);
        lobbyUIController.gameObject.SetActive(false);
    }
}
