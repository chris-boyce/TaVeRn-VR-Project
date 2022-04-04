using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class IgniteObject : MonoBehaviour
{
    private Renderer Renderer;
    public UnityEvent RunMissionCheck;
    private Light light;
    public bool isLit;
    private void Start()
    {
        Renderer = GetComponent<Renderer>();
        light = GetComponent<Light>();
        light.enabled = false;

    }
    public void Light()
    {
        isLit = true;
        light.enabled = true;
        Renderer.material.color = Color.red;
        RunMissionCheck.Invoke();
    }

}
