using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverChecker : MonoBehaviour
{
    public bool isPour;
    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.down) < -0.8)
        {
            isPour = true;
        }
        else
        {
            isPour = false;
        }
            
    }
}
