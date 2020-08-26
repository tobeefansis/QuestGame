using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour
{
    public Canvas canvas;
    public void Show() => canvas.gameObject.SetActive(true);
    public void Hide() => canvas.gameObject.SetActive(false);

    public void Use() {
    }
}
