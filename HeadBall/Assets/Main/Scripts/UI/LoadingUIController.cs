using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LoadingUIController : MonoBehaviour
{
    [SerializeField] private Transform progressT;
    [SerializeField] private AnimationCurve progressCurve;
    [SerializeField] private TextMeshProUGUI dotTmp;

    private void OnEnable()
    {
        StartCoroutine(RotateLoadingCircle());
        StartCoroutine(WriteDotText());
    }

    private void OnDisable()
    {
        progressT.DOComplete();
    }

    private float rotation;
    private float rotationSpeed = 115;

    IEnumerator RotateLoadingCircle()
    {
        while (true)
        {
            rotation = Random.Range(150, 250);
            yield return progressT.transform.DORotate(Vector3.forward * rotation, rotation / rotationSpeed).SetEase(progressCurve).SetRelative().WaitForCompletion();
        }
    }

    private float dotInterval = .5f;
    private float dotResetInterval = 1f;

    IEnumerator WriteDotText()
    {
        while (true)
        {
            dotTmp.text = "";
            yield return new WaitForSeconds(dotInterval);
            dotTmp.text = ".";
            yield return new WaitForSeconds(dotInterval);
            dotTmp.text = "..";
            yield return new WaitForSeconds(dotInterval);
            dotTmp.text = "...";
            yield return new WaitForSeconds(dotResetInterval);
        }
    }
}