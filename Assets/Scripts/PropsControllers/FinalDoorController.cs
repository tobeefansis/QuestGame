using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoorController : MonoBehaviour
{
    public bool playerHaveKey = false;
    private bool isCheked = false;
    [SerializeField] private Animator door;
    [SerializeField] private Animator doorHandler;
    [SerializeField] private AudioSource doorClosed;
    [SerializeField] private AudioSource doorOpened;
    public void Check()
    {
        if (playerHaveKey)
        {
            OpenDoor();
        }
        else
        {
            Closed();
        }
    }
    private void OpenDoor()
    {
        door.Play("Open");
        doorHandler.Play("DoorOpenHandler");
        doorOpened.Play();
        Invoke("Title", 1.5f);
    }
    private void Closed()
    {
        isCheked = !isCheked;
        doorHandler.SetBool("isCheked", isCheked);
        doorClosed.Play();
    }
    private void Title()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
