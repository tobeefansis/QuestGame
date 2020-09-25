using System;
using System.Collections;
using System.Collections.Generic;

using ExitGames.Client.Photon;

using Photon.Pun;
using Photon.Realtime;

using UnityEditor;

using UnityEngine;

public abstract class SavedObject : MonoBehaviour, IOnEventCallback
{
    public enum EventType
    {
        Nope,
        Door,
        Safe,
        Candle,
        Laptop
    }
    [Serializable]
    public class Arg
    {
        public int id;
        public EventType type;

        public Arg(int id, EventType type)
        {
            this.id = id;
            this.type = type;
        }
    }

    public bool IsMultiplayer;
    public string path;
    EventType eventType;

    public void Save()
    {
        PlayerPrefs.SetString(path, GetValue());
    }

    private void OnEnable()
    {
        if (IsMultiplayer)
        {
            PhotonNetwork.AddCallbackTarget(this);
        }
        else
        {
            Load();
        }
    }
    private void OnDisable()
    {
        if (IsMultiplayer)
        {

            PhotonNetwork.RemoveCallbackTarget(this);
        }
        else
        {
            Save();
        }
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

    public abstract void Event(string arg);

    public void OnEvent(EventData photonEvent)
    {
        Event((string)photonEvent.CustomData);
    }

    public void InvokeEvent(EventType type, string json)
    {
        RaiseEventOptions options = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        SendOptions sendOptions = new SendOptions { Reliability = true };
        PhotonNetwork.RaiseEvent((byte)type, json, options, sendOptions);
    }
}
