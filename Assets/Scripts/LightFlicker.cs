using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light light;
    private Color OriginalColor;
    public float FrequencyOfChange = 0.3f;
    public float BrightnessChange = 0.5f;
    public float StartBrightness = 2f;
    public float StartWavePos = 0;
    private void Start()
    {
        light = GetComponent<Light>();
        OriginalColor = light.color;
        StartWavePos = (Random.Range(0.0f, 3.0f));
    }
    void Update()
    {
        light.color = OriginalColor * (LightFlickers());
    }
    float LightFlickers()
    {
        float x = (Time.time + StartWavePos) * FrequencyOfChange;
        float y;
        x = x - (Mathf.Floor(x)); //Rounds the Number

        y = Mathf.Sin(x * 2 * Mathf.PI);
        return (y * BrightnessChange) + StartBrightness;
    }
}
