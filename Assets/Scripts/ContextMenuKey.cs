using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextMenuKey : MonoBehaviour
{
    [SerializeField] Text ActionText;
    [SerializeField] Text ActionKeyIcon;

    public void Set(KeyAction keyAction)
    {
        ActionText.text = keyAction.name;
        ActionKeyIcon.text = keyAction.key.ToString();
    }
}
