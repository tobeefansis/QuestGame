using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [Header("Keypad settings")]
    public string currentPassword = "1234";
    public string input = "";
    public Text displayText;
    public AudioSource correctPassword;
    public AudioSource incorrectPassword;
    public Animator openSafe;
    [SerializeField] GameObject disable;

    private int buttonClicked = 0;
    private int numberOfChars;

    public void Start()
    {
        numberOfChars = currentPassword.Length;
    }
    void CheckLength()
    {
        if (input.Length == numberOfChars)
        {
            CheckPass();
        }
    }

    private void CheckPass()
    {
        if (input == currentPassword)
        {
            correctPassword.Play();
            displayText.gameObject.SetActive(false);
            var cam = FindObjectOfType<SmartCam>();
            cam.HideObject();
            openSafe.SetBool("IsOpen", true);
            disable.GetComponent<InteractiveObject>().enabled = false;
            disable.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            input = "";
            buttonClicked = 0;
            displayText.text = input.ToString();
            incorrectPassword.Play();
        }
    }

    public void ValueEntered(string valueEntered)
    {
        buttonClicked++;
        input += valueEntered;
        displayText.text = input.ToString();
        CheckLength();
    }

}
