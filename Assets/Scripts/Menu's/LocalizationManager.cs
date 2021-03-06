﻿using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Path = System.IO.Path;
using UnityEngine.SceneManagement;

public class LocalizationManager : MonoBehaviour
{
    private Dictionary<string, string> localizedText = new Dictionary<string, string>();
    public static LocalizationManager instance;
    private string missingTextString = "LocalizedTextNotFound";
    void Awake()
    {
        // Синглтон для инициализации только одного объекта
        if (instance == null)
        {
            instance = this;
        }
            
        else
        {
            Destroy(this);
        }
           
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        #region Set system language 
        if (Application.systemLanguage == SystemLanguage.English)
        {
            LoadLocalizedText("LocalizedText_en.json");
        }
        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            LoadLocalizedText("LocalizedText_ru.json");
        }
        else
        {
            LoadLocalizedText("LocalizedText_en.json");
        }
        #endregion
    }
    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
        {
            // Парсим всю информацию из json'a в стрингу jsonData
            string jsonData = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(jsonData);
            // Помещаем json в Dictionary 
            for (int i = 0; i < loadedData.Items.Length; i++)
            {
                localizedText.Add(loadedData.Items[i].key, loadedData.Items[i].value);
            }
            Refresh();
        }
        else
        {
            Debug.LogError("Cannot find file :(");
        }
    }
    public void Refresh()
    {
        var items = FindObjectsOfType<LocalizationKey>();
        foreach (var item in items)
        {
            item.Load();
        }
    }
    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;

    }
}
