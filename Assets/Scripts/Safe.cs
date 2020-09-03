using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : InteractiveObject
{
    [SerializeField] Animation openDoor;
    [SerializeField] Animation closeDoor;
    public void OpenDoor()
    {
        openDoor.Play();
    }
    public void CloseDoor ()
    {
        closeDoor.Play();
    }
}

