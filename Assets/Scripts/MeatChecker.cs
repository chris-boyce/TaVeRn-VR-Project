using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatChecker : MonoBehaviour
{
    public GameObject Meat;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Meat")
        {
            Meat = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Meat = null;
    }

}
