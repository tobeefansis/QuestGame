using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Photon.Pun;


public class CandleSave : SavedObject
{
    public class CandleArg : Arg
    {
        public bool IsLight;

        public CandleArg(bool IsLight, int id, EventType type) : base(id, type)
        {
            this.IsLight = IsLight;
        }
    }

    [SerializeField] GameObject target;
    [SerializeField] bool IsLight;
    [SerializeField] int id;

    public void IsOpen()
    {
        IsLight = !IsLight;
        if (IsMultiplayer)
        {
            InvokeEvent(EventType.Candle, JsonUtility.ToJson(new CandleArg(IsLight, id, EventType.Candle)));
        }
        else
        {
            target.SetActive(IsLight);
        }
    }

    public UnityEvent OnChange;

    public override void Event(string arg)
    {
        if (JsonUtility.FromJson<CandleArg>(arg) is CandleArg candleArg && candleArg.type == EventType.Candle && candleArg.id == id)
        {
            IsLight = candleArg.IsLight;
            target.SetActive(IsLight);
        }
    }
}
