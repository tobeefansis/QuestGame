using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public bool isOpen;
    public static bool isBroken;
    private void Start()
    {
        isOpen = false;
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
