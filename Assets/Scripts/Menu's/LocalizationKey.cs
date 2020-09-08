using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationKey : MonoBehaviour
{
    [Tooltip("Ключевое слово для перевода ввести с маленькой буквы, вместро пробелом использовать нижнее подчеркивание \"_\"")]
    public string key;
    Text text;
    void Awake()
    {
        text = GetComponent<Text>();
    }
    private void OnEnable()
    {
        Invoke("Load()", 0.2f);
    }
    public void Load()
    {
        var text = LocalizationManager.instance.GetLocalizedValue(key);
        this.text.text = text;
    }
}
