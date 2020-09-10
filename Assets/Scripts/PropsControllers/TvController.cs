using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour
{
    [SerializeField] bool isOn = false;

    public void TurnOnOff()
    {
        isOn = !isOn;
        this.gameObject.SetActive(isOn);
    }
}
