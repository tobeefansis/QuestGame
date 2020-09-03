using UnityEngine;
using System.Collections;

public class ContextMenu : MonoBehaviour, IPause
{
    public void ChangeSelectObject(InteractiveObject before, InteractiveObject after)
    {
    
        if (before) before.Hide();
        if (after) after.Show();
    }

    public void Pause()
    {
        gameObject.SetActive(false);
    }

    public void Resume()
    {
        gameObject.SetActive(true);
    }
}
