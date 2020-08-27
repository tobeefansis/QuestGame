using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт задает настройки языка
public class LanguageManager : MonoBehaviour
{
    private void Awake()
    {
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            SetRussian();
        }
        else if (Application.systemLanguage == SystemLanguage.English)
        {
            SetEnglish();
        }
    }

    private void SetRussian()
    {
        throw new NotImplementedException();
    }

    private void SetEnglish()
    {
        throw new NotImplementedException();
    }
    #region Language SetMethods
    /*public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
    }
    public void SetRussian()
    {
        Localize.SetCurrentLanguage(SystemLanguage.Russian);
    }*/
    #endregion
}
