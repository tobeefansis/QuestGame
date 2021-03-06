﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class SmartCam : MonoBehaviour
{
    public Transform FinishCamPosition;
    Transform LastCameraParent;
    public float Duration;
    Vector3 lastPos;
    Vector3 lastRot;

    public void ShowObject()
    {
        print("ShowObject");
        PauseManager.Instance.PauseWithoutMenu();
        var cam = Camera.main.transform;
        LastCameraParent = cam.parent; cam.parent = null;
        lastPos = cam.position;
        lastRot = cam.rotation.eulerAngles;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(cam.DOMove(FinishCamPosition.position, Duration));
        sequence.Join(cam.DORotate(FinishCamPosition.rotation.eulerAngles, Duration));
    }

    public void HideObject()
    {
        print("HideObject");
        var cam = Camera.main.transform;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(cam.DOMove(lastPos, Duration)); ;
        sequence.Join(cam.DORotate(lastRot, Duration));
        sequence.onComplete += Complite;

    }

    private void Complite()
    {
        Camera.main.transform.parent = LastCameraParent;
        Camera.main.transform.localEulerAngles = new Vector3(0, 0, 0);
        Camera.main.transform.localPosition = new Vector3(0, 0, 0);
        PauseManager.Instance.Resume();
    }
}
