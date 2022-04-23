using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InGameUI : Singleton<InGameUI>
{
    public GameObject goalText;

    public void ChangeActiveGoalText(bool willEnable)
    {
        DOTween.Complete("goalText");
        if (willEnable)
        {
            goalText.gameObject.SetActive(true);
            goalText.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutBounce).From(Vector3.zero).SetId("goalText");
            return;
        }

        goalText.transform.DOScale(Vector3.zero, .3f).SetEase(Ease.InBack).SetId("goalText").From(Vector3.one)
            .OnComplete(
                () => { goalText.gameObject.SetActive(false); });
    }
}