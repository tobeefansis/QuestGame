using UnityEngine;
using System.Collections;

public class ContextMenu : MonoBehaviour, IPause
{
    public void ChangeSelectObject(InteractiveObject before, InteractiveObject after)
    {
    
        if (before) before.Hide();
        if (after) after.Show();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
