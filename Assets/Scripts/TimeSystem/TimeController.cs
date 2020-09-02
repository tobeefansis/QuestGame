using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TimeController : MonoBehaviour
{
    private const int SecondsPerDay = 86400;
    public float time;
    [Range(0, 10000)] public int timeScale = 1;

    private static TimeController instance;

    public static TimeController Instance { get => instance; private set => instance = value; }

    public string Now => $"{Hour,2}:{Minute,2}:{Second,2}";
    public int Second => (int)time % 60;
    public int Minute => ((int)time % 3600) / 60;
    public int Hour => (int)time / 3600;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            var _now = DateTime.Now;
            time = _now.Second + _now.Minute * 60 + _now.Hour * 3600;
        }
        else
        {
            Destroy(this);
        }
    }

    void LateUpdate()
    {
        time += Time.deltaTime * timeScale;
        if (time >= SecondsPerDay)
        {
            time -= SecondsPerDay;
        }
    }
}
