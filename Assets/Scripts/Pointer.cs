using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

[Serializable]
public class InteractiveObjectEvent : UnityEvent<InteractiveObject> { }

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
            OnChangeSelectObject.AddListener(FindObjectOfType<ContextMenu>().ChangeSelectObject);
        }
        else
        {
            Destroy(this);
        }
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
                Debug.DrawLine(hit.point, ray.origin,Color.red);
                var interactiveObject = hit.transform.GetComponent<InteractiveObject>();


                if (hit.distance < distance)
                {
                    if (selectObject != interactiveObject)
                    {
                        OnChangeSelectObject.Invoke(interactiveObject);
                        selectObject = interactiveObject;
                    }
                }
                else
                {
                    if (selectObject != null)
                    {
                        OnChangeSelectObject.Invoke(null);
                        selectObject = null;
                    }
                }
            }
            else
            {
                if (selectObject != null)
                {
                    OnChangeSelectObject.Invoke(null);
                    selectObject = null;
                }
            }
            yield return null;
        }
    }

    public void Pause()
    {
        if (corutine!=null)
        {
            StopCoroutine(corutine);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Resume()
    {
        corutine = StartCoroutine(Look()); 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
