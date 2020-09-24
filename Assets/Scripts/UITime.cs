using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{
    [SerializeField] Text text;
    private void LateUpdate()
    {
        var timeCtrl = TimeController.Instance;
        text.text = timeCtrl.Now;
    }
}
