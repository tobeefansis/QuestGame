using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DoorControllerSave), typeof(Animator))]
public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] DoorControllerSave save;

    private void Awake()
    {
        save = GetComponent<DoorControllerSave>();
        save.OnChange.AddListener(Change);
    }

    public void Change()
    {
        animator.SetBool("isOpen", save.IsOpen);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        save.OnChange.AddListener(Change);
        save.IsOpen = false;
    }
    public void OpenClose()
    {
        save.IsOpen = !save.IsOpen;
        Change();
    }
}
