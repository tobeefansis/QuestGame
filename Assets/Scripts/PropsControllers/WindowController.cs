using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public bool isOpen;
    private void Start()
    {
        isOpen = false;
    }
    public void Break()
    {
        GetComponent<BreakableWindow>().breakWindow();
    }
    public void OpenClose()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }
}
