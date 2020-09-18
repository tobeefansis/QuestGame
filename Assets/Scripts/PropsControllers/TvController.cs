using UnityEngine;

public class TvController : MonoBehaviour
{
    [SerializeField] private bool isOn = false;
    public void TurnOnOff()
    {
        isOn = !isOn;
        this.gameObject.SetActive(isOn);
    }
}
