using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Photon.Pun;


public class LaptopControllerSave : SavedObject
{
    public class LaptopControllerArg : Arg
    {
        public bool IsPlayerUsage;

        public LaptopControllerArg(bool IsPlayerUsage, int id, EventType type) : base(id, type)
        {
            this.IsPlayerUsage = IsPlayerUsage;
        }
    }

    [SerializeField] InteractiveObject target;
    [SerializeField] bool IsPlayerUsage;
    [SerializeField] int id;

    public void IsOpen()
    {
        IsPlayerUsage = !IsPlayerUsage;
        if (IsMultiplayer)
        {
            InvokeEvent(EventType.Laptop, JsonUtility.ToJson(new LaptopControllerArg(IsPlayerUsage, id, EventType.Laptop)));
        }
        else
        {
            target.enabled = IsPlayerUsage;
        }
    }


    public override void Event(string arg)
    {
        if (JsonUtility.FromJson<LaptopControllerArg>(arg) is LaptopControllerArg candleArg && candleArg.type == EventType.Laptop && candleArg.id == id)
        {
            IsPlayerUsage = candleArg.IsPlayerUsage;
            target.enabled = IsPlayerUsage;

        }
    }
}
