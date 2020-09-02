using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Watch : MonoBehaviour
{
    [SerializeField] GameObject pointerSeconds;
    [SerializeField] GameObject pointerMinutes;
    [SerializeField] GameObject pointerHours;


    // Update is called once per frame
    private void LateUpdate()
    {
        var timeCtrl = TimeController.Instance;
        float rotationSeconds = (360.0f / 60.0f) * timeCtrl.Second;
        float rotationMinutes = (360.0f / 60.0f) * timeCtrl.Minute;
        float rotationHours = ((360.0f / 12.0f) * timeCtrl.Hour) + ((360.0f / (60.0f * 12.0f)) * timeCtrl.Minute);

        //-- draw pointers
        pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
    }
}
