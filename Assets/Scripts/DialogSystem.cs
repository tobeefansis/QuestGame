using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] List<Message> messages = new List<Message>();
    [SerializeField] Text text;
    Message Select => messages[index];
    int index;

    public void Play()
    {
        PauseManager.Instance.Pause();
        index = 0;
        Show();
    }

    private void Show()
    {
        text.text = Select.Text;
    }

    private void OnEnable()
    {
        Play();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Step();
        }
    }
    public void Step()
    {
        index++;
        if (index <= messages.Count)
        {
            Show();
        }
        else
        {
            PauseManager.Instance.Resume();
            gameObject.SetActive(false);
        }
    }
}
[SerializeField]
public struct Message
{
    public string Text;
}
