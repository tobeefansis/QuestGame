using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationKey : MonoBehaviour
{
    [Tooltip("Ключевое слово для перевода ввести с маленькой буквы, пробелы соблюдать")]
    public string key;
    void Start()
    {
        Load();
    }
    private void OnEnable()
    {
        Load();
    }
    public void Load()
    {
        Text text = GetComponent<Text>();
        text.text = LocalizationManager.instance.GetLocalizedValue(key);
    }
}
