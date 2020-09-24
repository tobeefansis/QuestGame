using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public class InteractiveObject : MonoBehaviour, IPause
{
    public List<KeyAction> keyActions = new List<KeyAction>();
    public AudioClip Clip;
    public AudioSource Source;

    public bool IsShow;
    public bool IsPause;
    public bool IsAudioEffect;

    public void Show()
    {
        IsShow = true;
    }

    public void Hide()
    {
        IsShow = false;
    }

    public void Toggle(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    private void Update()
    {
        if (IsShow && !IsPause)
        {
            foreach (var item in keyActions)
            {
                if (Input.GetKeyDown(item.key))
                {
                    item.action?.Invoke();
                }
            }
            if (IsAudioEffect && Source)
            {
                Source.clip = Clip;
                Source.Play();
            }
        }
    }

    public void Pause()
    {
        IsPause = true;
    }

    public void Resume()
    {
        IsPause = false;

    }
}

[Serializable]
public class KeyAction
{
    public string name;
    public KeyCode key;
    public UnityEvent action;
}