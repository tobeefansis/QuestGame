using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Localize : MonoBehaviour
{
    [SerializeField] Button button;
    private const char Separator = '=';
    private readonly Dictionary<string, string> languageList = new Dictionary<string, string>();
    private SystemLanguage language;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SetSystemLanguage();
    }

    #region Set Language Methods
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
    public void SetRussian()
    {
        language = SystemLanguage.Russian;
        var file = Resources.Load<TextAsset>(SystemLanguage.Russian.ToString());
        language = SystemLanguage.Russian;
        if (file == null)
        {
            file = Resources.Load<TextAsset>(SystemLanguage.Russian.ToString());
            language = SystemLanguage.Russian;
        }
        foreach (var line in file.text.Split('\n'))
        {
            var word = line.Split(Separator);
            languageList[word[0]] = word[1];
        }
    }
    public void SetEnglish()
    {
        language = SystemLanguage.English;
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
    #endregion
    public void TranslateText()
    {
        var localizations = Resources.FindObjectsOfTypeAll<LocalizationKey>();
        foreach (var key in localizations)
        {
            var text = key.GetComponent<Text>();
            text.text = Regex.Unescape(languageList[key.KeyWord]);
        }
    }
}
