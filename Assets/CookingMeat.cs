using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CookingMeat : MonoBehaviour
{
    public UnityEvent RunCompletedTask;
    public Color[] CookingColors;
    public int counter = 0;
    private bool inOven;
    public Renderer renderer;
    private bool taskedFinshed = false;

    private float timeLeft = 5f;
    private void Start()
    {
        taskedFinshed = false;
        renderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Oven")
        {
            inOven = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Oven")
        {
            inOven = false;
        }
    }
    private void Update()
    {
        if(inOven == true)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                counter++;
                renderer.material.color = CookingColors[counter];
                if (counter < 4 && taskedFinshed == false)
                {
                    Debug.Log("Fired Event");
                    taskedFinshed = true;
                    RunCompletedTask.Invoke();
                }
                timeLeft = 5f;
            }
        }
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
        
}
