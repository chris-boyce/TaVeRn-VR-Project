using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugController : MonoBehaviour
{
    public GameObject liquid;
    private SocketTarget sockettarget;
    public bool isFull;


    private void Start()
    {
        sockettarget = GetComponent<SocketTarget>();
        liquid.SetActive(false);
        isFull = false;
    }
    public void FillCup()
    {
        sockettarget.SocketType = "Mug";
        liquid.SetActive(true);
        isFull = true;
    }
    public void EmptyCup()
    {
        sockettarget.SocketType = "EmptyMug";
        Debug.Log("DEStroyed liquid");
        liquid.SetActive(false);
        isFull = false;
    }
}
