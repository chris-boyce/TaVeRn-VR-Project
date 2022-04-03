using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SignFliping : MonoBehaviour
{
    public bool isOpen = false;
    public UnityEvent RunMissionCheck;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "SignArea")
        {
            if (transform.rotation.z >= 0.8)
            {
                isOpen = true;
            }
            else
            {
                isOpen= false;
            }
            RunMissionCheck.Invoke();
        }


    }

}
