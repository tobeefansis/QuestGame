using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localize : MonoBehaviour
{
    private const char Separator = '=';
    private readonly Dictionary<string, string> languageList = new Dictionary<string, string>();
    private SystemLanguage language;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void SetLanguage()
    {
        language = Application.systemLanguage;
        var file = Resources.Load<TextAsset>(SystemLanguage.English.ToString());
        language = SystemLanguage.English; ;
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
       // var 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
