using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEndPanel : MonoBehaviour
{
    [SerializeField] private GameObject succesPanel;
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject goBackToLobbyButton;

    private void Awake()
    {
        goBackToLobbyButton.gameObject.SetActive(false);
    }

    public void OpenSuccesPanel()
    {
        failPanel.gameObject.SetActive(false);
        succesPanel.gameObject.SetActive(true);

        succesPanel.transform.DOScale(Vector3.one, .6f).SetEase(Ease.OutBack).From(Vector3.zero).OnComplete(OpenGoBackToLobbyButton);
    }
    
    public void OpenFailPanel()
    {
        failPanel.gameObject.SetActive(true);
        succesPanel.gameObject.SetActive(false);

        failPanel.transform.DOScale(Vector3.one, .6f).SetEase(Ease.OutBack).From(Vector3.zero).OnComplete(OpenGoBackToLobbyButton);
    }

    public void OpenGoBackToLobbyButton()
    {
        goBackToLobbyButton.gameObject.SetActive(true);
        goBackToLobbyButton.transform.DOScale(Vector3.one, .4f).SetEase(Ease.OutBack).From(Vector3.zero).OnComplete(() =>
        {
            goBackToLobbyButton.GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene(0));
        });
    }
}
