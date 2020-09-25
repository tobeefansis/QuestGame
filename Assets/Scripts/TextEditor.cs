using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    [SerializeField] InputField text;

    [SerializeField] TextFile select;

    public void SetTextFile(TextFile file)
    {
        select = file;
        if (text && select)
        {

            text.text = select.text;
        }
    }

    public void SaveText(string text)
    {
        select.text = text;
        this.text.text = select.text;
    }
    public void SaveText() => SaveText(text.text);

    public void ResetButton(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }


}
[CreateAssetMenu()]
public class TextFile : ScriptableObject
{
    [TextArea()] public string text;
}