using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    [SerializeField] InputField text;

    TextFile select;

    public void SetTextFile(TextFile file)
    {
        select = file;
        text.text = select.text;
    }

    public void SaveText(string text)
    {
        select.text = text;
    }
}
[CreateAssetMenu()]
public class TextFile : ScriptableObject
{
    [TextArea()] public string text;
}