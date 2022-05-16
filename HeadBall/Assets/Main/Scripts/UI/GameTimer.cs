using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTmp;

    private int maxTime = 180;
    private int timeLeft;
    private string totalTimeString;
    private int minutes;
    private string seconds;

    void Start()
    {
        InitTimer();
    }

    private void InitTimer()
    {
        timeLeft = maxTime;
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            SetTimerTmp();
        }
        
        LevelConditions.OnGameEnds?.Invoke();
    }

    private void SetTimerTmp()
    {
        minutes = timeLeft / 60;
        seconds = GetSecondsLeft();

        totalTimeString = minutes + ":" + seconds;
        timerTmp.SetText(totalTimeString);
    }

    private string GetSecondsLeft()
    {
        if (timeLeft % 60 < 10)
        {
            return "0" + (timeLeft % 60);
        }

        return (timeLeft % 60).ToString();
    }
}