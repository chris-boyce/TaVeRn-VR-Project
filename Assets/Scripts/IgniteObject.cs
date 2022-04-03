using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class IgniteObject : MonoBehaviour
{
    private Renderer Renderer;
    public UnityEvent RunMissionCheck;
    public bool isLit;
    private void Start()
    {
        Renderer = GetComponent<Renderer>();
    }
    public void Light()
    {
        isLit = true;
        Renderer.material.color = Color.red;
        RunMissionCheck.Invoke();
    }

}
