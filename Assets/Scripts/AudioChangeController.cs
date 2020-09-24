using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChangeController : MonoBehaviour
{
    [SerializeField] private AudioSource ambient;
    public bool isOutside = false;
    
    public void ChangeSound()
    {
        isOutside = !isOutside;
        if (isOutside)
        {
            Increase();
        }
        else if (!isOutside)
        {
            Decrease();
        }
    }

    private void Decrease() => ambient.volume = 0.1f;

    private void Increase() => ambient.volume = 0.6f;
}
