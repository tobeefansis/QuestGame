using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public void Break()
    {
        GetComponent<BreakableWindow>().breakWindow();
    }
}
