using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoubleClickButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
    [SerializeField] UnityEvent onDoubleClick;
    public UnityEvent OnDoubleClick { get => onDoubleClick; }
    public bool IsDouble = false;
    public float time = .3f;

    IEnumerator Timer()
    {
        IsDouble = true;
        yield return new WaitForSeconds(time);
        IsDouble = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsDouble)
        {
            onDoubleClick.Invoke();
            IsDouble = false;
        }
        else
        {
            StartCoroutine(Timer());
        }
    }
}
