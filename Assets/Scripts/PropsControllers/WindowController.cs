using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public bool isOpen;
    public bool isBroken;
    private void Start()
    {
        isOpen = false;
        isBroken = false;
    }
    public void Break()
    {
        GetComponent<BreakableWindow>().breakWindow();
        isBroken = true;
    }
    public void OpenClose()
    {
        if (!isBroken)
        {
            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);
        }
    }
}
