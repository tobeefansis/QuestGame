using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public abstract class SavedObject : MonoBehaviour
{
    public string path;
    public void Save()
    {
        PlayerPrefs.SetString(path, GetValue());
    }
    private void OnEnable()
    {
        Load();
    }
    private void OnDisable()
    {
        Save();
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    public string GetValue()
    {
        return JsonUtility.ToJson(this);
    }

    public void SetValue(string value)
    {
        JsonUtility.FromJsonOverwrite(value, this);
    }
 
    public void Load()
    {
        if (!SaveController.instance.IsNewGame)
        {
            var str = PlayerPrefs.GetString(path);
            SetValue(str);
        }
    }
    private void Awake()
    {
        Load();
    }

}
