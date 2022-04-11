using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotate : MonoBehaviour
{
    public GameObject Player;
    private void Start()
    {
        Player = GameObject.Find("XRBodyCollider");
    }
    void Update()
    {
        transform.LookAt(Player.transform.position);
    }
}
