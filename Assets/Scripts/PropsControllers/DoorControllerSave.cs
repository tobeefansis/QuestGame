using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.Events;

public class DoorControllerSave : SavedObject
{
    public class DoorControllerArg : Arg
    {
        public bool isOpen;

        public DoorControllerArg(bool isOpen, EventType type, int id) : base(id, type)
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
            InvokeEvent(EventType.Door, JsonUtility.ToJson(new DoorControllerArg(isOpen, EventType.Door, id)));
        }
    }

    public override void Event(string arg)
    {
        if (JsonUtility.FromJson<DoorControllerArg>(arg) is DoorControllerArg doorControllerArg && doorControllerArg.type == EventType.Door && doorControllerArg.id == id)
        {
            isOpen = doorControllerArg.isOpen;
            OnChange.Invoke();
        }
    }
}
