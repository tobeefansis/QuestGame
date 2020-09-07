using UnityEngine;
using System.Collections;

public class ContextMenu : MonoBehaviour, IPause
{
    [SerializeField] Transform IconTarget;
    [SerializeField] ContextMenuKey keyPrefub;
    [SerializeField] InteractiveObject selected;

    public void ChangeSelectObject(InteractiveObject selected)
    {
        if (this.selected)
        {
            this.selected.Hide();
        }
        this.selected = selected;

        for (int i = 0; i < IconTarget.childCount; i++)
        {
            Destroy(IconTarget.GetChild(i).gameObject);
        }

        if (selected)
        {
            selected.Show();
            foreach (var item in selected.keyActions)
            {
                Instantiate(keyPrefub, IconTarget).Set(item);
            }
        }
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
