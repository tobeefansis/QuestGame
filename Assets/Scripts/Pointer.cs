using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour, IPause
{
    public static Pointer Instance;

    [SerializeField] Transform PointerUI;
    [SerializeField] LayerMask layerMask;
    Camera cam;

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
        cam = Camera.main;
    }
    public Transform position;

    private void LateUpdate()
    {

        if (Physics.Raycast(cam.ScreenPointToRay(PointerUI.position), out RaycastHit hit, layerMask))
        {
            if (hit.transform)
            {

            }
        }
    }

    public void Pause()
    {
        throw new System.NotImplementedException();
    }

    public void Resume()
    {
        throw new System.NotImplementedException();
    }
}
