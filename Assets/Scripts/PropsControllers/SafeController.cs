using System.Collections;
using System.Collections.Generic;

using UnityEngine;
/*[RequireComponent(typeof(Animator), typeof(SafeControllerSave))]
public class SafeController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SafeControllerSave save;

    private void Awake()
    {
        save = GetComponent<SafeControllerSave>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
    }
    public void OpenClose()
    {
        save.IsOpen = !save.IsOpen;
        Change();
    }

    private void Change()
    {
        animator.SetBool("IsOpen", save.IsOpen);
    }
}*/
