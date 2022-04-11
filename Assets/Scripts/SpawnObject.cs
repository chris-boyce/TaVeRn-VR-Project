using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject SpawnedObject;

    public void SpawnObjects()
    {
        Instantiate(SpawnedObject, transform.position, Quaternion.identity);
    }

}
