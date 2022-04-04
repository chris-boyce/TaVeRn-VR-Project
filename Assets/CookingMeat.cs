using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMeat : MonoBehaviour
{
    public Color[] CookingColors;
    public int counter = 0;
    private bool inOven;
    public Renderer renderer;
    private float timeLeft = 5f;
    private void Start()
    {
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
            Debug.Log("SOme cook");
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                counter++;
                renderer.material.color = CookingColors[counter];
                timeLeft = 5f;
            }
        }
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
        
}
