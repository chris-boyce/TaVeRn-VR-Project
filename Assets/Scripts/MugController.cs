using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugController : MonoBehaviour
{
    public GameObject liquid;
    private SocketTarget sockettarget;
    public bool isFull;
    private AudioSource source;
    public AudioClip Drinking;
    public AudioClip Filling;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        sockettarget = GetComponent<SocketTarget>();
        liquid.SetActive(false);
        isFull = false;
    }
    public void FillCup()
    {
        source.clip = Filling;
        source.Play();
        sockettarget.SocketType = "Mug";
        liquid.SetActive(true);
        isFull = true;
    }
    public void EmptyCup()
    {
        source.clip = Drinking;
        source.Play();
        sockettarget.SocketType = "EmptyMug";
        Debug.Log("DEStroyed liquid");
        liquid.SetActive(false);
        isFull = false;
    }
}
