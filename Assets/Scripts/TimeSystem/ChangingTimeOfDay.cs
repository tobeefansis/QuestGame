using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ChangingTimeOfDay : MonoBehaviour
{
    [SerializeField] AnimationCurve SunCurve;
    [SerializeField] AnimationCurve MoonCurve;
    [SerializeField] AnimationCurve SkyboxCurve;

    [SerializeField] Material DaySkybox;
    [SerializeField] Material NightSkybox;

    [SerializeField] ParticleSystem Stars;

    [SerializeField] Light Sun;
    [SerializeField] Light Moon;

    private float sunIntensity;
    private float moonIntensity;

    private void Start()
    {
        sunIntensity = Sun.intensity;
        moonIntensity = Moon.intensity;
    }

    private void Update()
    {
        var TimeOfDay = TimeController.Instance.TimeOfDay;

        RenderSettings.skybox.Lerp(NightSkybox, DaySkybox, SkyboxCurve.Evaluate(TimeOfDay));
        RenderSettings.sun = SkyboxCurve.Evaluate(TimeOfDay) > 0.1f ? Sun : Moon;
        DynamicGI.UpdateEnvironment();

        var mainModule = Stars.main;
        mainModule.startColor = new Color(1, 1, 1, 1 - SkyboxCurve.Evaluate(TimeOfDay));

        Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f, 180, 0);
        Moon.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f + 180f, 180, 0);

        Sun.intensity = sunIntensity * SunCurve.Evaluate(TimeOfDay);
        Moon.intensity = moonIntensity * MoonCurve.Evaluate(TimeOfDay);
    }
}
