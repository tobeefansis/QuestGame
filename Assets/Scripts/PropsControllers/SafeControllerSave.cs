using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Photon.Pun;

public class SafeControllerSave : SavedObject
{
    public class SafeControllerArg : Arg
    {
        public bool isOpen;

        public SafeControllerArg(bool isOpen, EventType type, int id) : base(id, type)
        {
            this.isOpen = isOpen;
        }
    }

    public UnityEvent OnChange;
    [SerializeField] bool isOpen;
    [SerializeField] int id;

    public bool IsOpen
    {
        get => isOpen; set
        {
            isOpen = value;
            InvokeEvent(EventType.Door, JsonUtility.ToJson(new SafeControllerArg(isOpen, EventType.Door, id)));
        }
    }

    public override void Event(string arg)
    {
        if (JsonUtility.FromJson<SafeControllerArg>(arg) is SafeControllerArg doorControllerArg && doorControllerArg.type == EventType.Door && doorControllerArg.id == id)
        {
            isOpen = doorControllerArg.isOpen;
            OnChange.Invoke();
        }
    }
}
