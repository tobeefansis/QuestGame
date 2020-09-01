using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationKey : MonoBehaviour
{
    [Tooltip("Ключевое слово для перевода ввести с маленькой буквы, вместро пробелом использовать нижнее подчеркивание \"_\"")]
    public string key;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        Load();

    }
    private void OnEnable()
    {
        Load();
    }
    public void Load()
    {
        var text = LocalizationManager.instance.GetLocalizedValue(key);
        this.text.text = text;
    }
}
