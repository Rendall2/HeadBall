using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InGameUI : Singleton<InGameUI>
{
    public GameObject goalText;
    public ScoreBoardController ScoreBoardController;
    public LevelEndPanel levelEndPanel;
    public GameObject bg;


    private void Awake()
    {
        levelEndPanel.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
    }

    public IEnumerator ChangeActiveGoalText()
    {
        goalText.gameObject.SetActive(true);
        yield return goalText.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutBounce).From(Vector3.zero).WaitForCompletion();
        yield return goalText.transform.DOScale(Vector3.zero, .3f).SetEase(Ease.InBack).SetId("goalText").From(Vector3.one).WaitForCompletion();
        goalText.gameObject.SetActive(false);
    }

    public void SuccessGame()
    {
        bg.gameObject.SetActive(true);
        levelEndPanel.gameObject.SetActive(true);
        levelEndPanel.OpenSuccesPanel();
    }
    
    public void FailGame()
    {
        bg.gameObject.SetActive(true);
        levelEndPanel.gameObject.SetActive(true);
        levelEndPanel.OpenFailPanel();
    }
}