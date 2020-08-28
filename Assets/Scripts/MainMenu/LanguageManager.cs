using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Скрипт задает язык системы
public class LanguageManager : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<Localize>().TranslateText();
    }
}
