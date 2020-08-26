using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

[Serializable]
public class InteractiveObjectEvent : UnityEvent<InteractiveObject, InteractiveObject> { }

public class Pointer : MonoBehaviour, IPause
{
    public static Pointer Instance;

    [SerializeField] Transform PointerUI;
    [SerializeField] LayerMask layerMask;
    [SerializeField] [Range(1, 5)] float distance;
    public InteractiveObject selectObject;
    public InteractiveObjectEvent OnChangeSelectObject;

    Camera cam;
    Coroutine corutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    private void Start()
    {
        cam = Camera.main;
        corutine = StartCoroutine(Look());
    }

    IEnumerator Look()
    {
        while (true)
        {
            var ray = cam.ScreenPointToRay(PointerUI.position);

            if (Physics.Raycast(ray, out RaycastHit hit, 5, layerMask))
            {

                var interactiveObject = hit.transform.GetComponent<InteractiveObject>();


                if (hit.distance < distance)
                {
                    if (selectObject != interactiveObject)
                    {
                        OnChangeSelectObject.Invoke(selectObject, interactiveObject);
                        selectObject = interactiveObject;
                    }
                }
                else
                {
                    if (selectObject != null)
                    {
                        OnChangeSelectObject.Invoke(selectObject, null);
                        selectObject = null;
                    }
                }
            }
            else
            {
                if (selectObject != null)
                {
                    OnChangeSelectObject.Invoke(selectObject, null);
                    selectObject = null;
                }
            }
            yield return null;
        }
    }

    public void Pause()
    {
        StopCoroutine(corutine);
    }

    public void Resume()
    {
        corutine = StartCoroutine(Look());
    }
}
