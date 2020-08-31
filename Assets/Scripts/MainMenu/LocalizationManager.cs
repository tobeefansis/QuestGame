using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Path = System.IO.Path;
using UnityEngine.SceneManagement;

public class LocalizationManager : MonoBehaviour
{
    private Dictionary<string, string> localizedText;
    public static LocalizationManager instance;
    private bool isReady = false;
    private string missingTextString = "LocalizedTextNotFound";
    void Awake()
    {
        // Используем синглтон для инициализации только одного объекта
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
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
            Debug.Log("Contains " + localizedText.Count + " items");
            Refresh();
        }
        else
        {
            Debug.LogError("Cannot find file :(");
        }

        isReady = true;
    }

    public void Refresh()
    {
        var t = FindObjectsOfType<LocalizationKey>();
        foreach (var item in t)
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
    public bool GetIsReady() => isReady;
}
