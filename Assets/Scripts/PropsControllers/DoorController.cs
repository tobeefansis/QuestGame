using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public bool isOpen;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = false;
    }
    public void OpenClose()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }
}
