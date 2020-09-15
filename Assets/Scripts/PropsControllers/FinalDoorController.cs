﻿using System;
using UnityEngine;
public class FinalDoorController : MonoBehaviour
{
    public bool playerHaveKey = false;
    [SerializeField] Animator door;
    [SerializeField] Animator doorHandler;
    [SerializeField] AudioSource doorClosed;
    [SerializeField] AudioSource doorOpened;
    public void Check()
    {
        if (playerHaveKey)
        {
            OpenDoor();
            //doorOpened.Play();
        }
        else
        {
            Closed();
            //doorClosed.Play();
        }
    }
    private void OpenDoor()
    {
        door.Play("Open");
        doorHandler.Play("DoorOpenHandler");
        GetComponent<InteractiveObject>().enabled = false;
    }
    private void Closed()
    {
        doorHandler.Play("DoorClosedHandler");
        doorHandler.SetTrigger("defaultState");
    }
}
