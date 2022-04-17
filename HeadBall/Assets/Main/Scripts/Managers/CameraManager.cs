using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private Camera mainCam;

    public Camera MainCam
    {
        get
        {
            if (mainCam == null) return mainCam = Camera.main;
            return mainCam;
        }
    }
}
