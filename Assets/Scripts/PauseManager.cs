using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;
    [SerializeField] List<IPause> pauses = new List<IPause>();

    public List<IPause> Pauses { get => pauses; set => pauses = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            var objcets = FindObjectsOfType<Transform>();
            foreach (var item in objcets)
            {
                var obj = item.GetComponent<IPause>();
                if (obj != null)
                {
                    pauses.Add(obj);
                }
            }
        }
        else
        {
            Destroy(this);
        }

        Resume();

    }

    public void Pause()
    {
        pauses.ForEach(n => n.Pause());
    }

    public void Resume()
    {
        pauses.ForEach(n => n.Resume());
    }
}
