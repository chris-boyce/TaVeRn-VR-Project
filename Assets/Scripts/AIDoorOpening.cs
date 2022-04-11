using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDoorOpening : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Door")
        {
            Debug.Log("Collsion Enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            Debug.Log("Collision Exit");
        }
    }

}
