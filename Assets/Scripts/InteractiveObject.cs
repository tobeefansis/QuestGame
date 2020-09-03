using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public class InteractiveObject : MonoBehaviour
{
    public List<KeyAction> keyActions = new List<KeyAction>();
    public Canvas canvas;
    public bool IsShow;
    public void Show()
    {
        IsShow = true;
        canvas.gameObject.SetActive(true);
    }

    public void Hide()
    {
        IsShow = false;
        canvas.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (IsShow)
        {
            foreach (var item in keyActions)
            {
                if (Input.GetKeyDown(item.key))
                {
                    item.action?.Invoke();
                }
            }
        }
    }
}

[Serializable]
public class KeyAction
{
    public string name;
    public KeyCode key;
    public UnityEvent action;
}