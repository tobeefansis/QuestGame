using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Localize : MonoBehaviour
{
    private const char Separator = '=';
    private readonly Dictionary<string, string> languageList = new Dictionary<string, string>();
    private SystemLanguage language;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SetSystemLanguage();
    }

    void SetSystemLanguage()
    {
        language = Application.systemLanguage;
        var file = Resources.Load<TextAsset>(SystemLanguage.English.ToString());
        language = SystemLanguage.English;
        if (file == null)
        {
            file = Resources.Load<TextAsset>(SystemLanguage.English.ToString());
            language = SystemLanguage.English;
        }
        foreach (var line in file.text.Split('\n'))
        {
            var word = line.Split(Separator);
            languageList[word[0]] = word[1];
        }

    }

    void TranslateText()
    {
        var localizations = Resources.FindObjectsOfTypeAll<LocalizationKey>();
        foreach (var key in localizations)
        {
            var text = key.GetComponent<Text>();
            text.text = Regex.Unescape(languageList[key.KeyWord]);
        }
    }
}
