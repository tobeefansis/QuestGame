using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoorController : MonoBehaviour
{
    public bool playerHaveKey = false;
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
        doorHandler.SetTrigger("Check");
        doorClosed.Play();
        StartCoroutine(RunCloseAnimation());
    }
    IEnumerator RunCloseAnimation ()
    {
        yield return new WaitForSeconds(1.2f);
        doorHandler.SetTrigger("isCheked");
    }
    private void Title()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
