using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject AICharcter;
    public Transform spawnLocation;
    public void SpawnAI()
    {
        Instantiate(AICharcter , spawnLocation.position, Quaternion.identity);
    }
}
