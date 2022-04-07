using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [System.Serializable]
    public struct ChairAllocation
    {
        public GameObject Chair;
        public bool isFilled;
    }

    public GameObject AICharcter;
    public Transform spawnLocation;
    public ChairAllocation[] chairAllocation;
    public GameObject[] Chairs;
    private void Awake()
    {
        Chairs = GameObject.FindGameObjectsWithTag("Chair");
        chairAllocation = new ChairAllocation[Chairs.Length];
        for (int i = 0, len = Chairs.Length; i < len; i++)
        {
            chairAllocation[i].Chair = Chairs[i];
            chairAllocation[i].isFilled = false;
        }
    }
    public void SpawnAI()
    {
        Instantiate(AICharcter , spawnLocation.position, Quaternion.identity);
        Instantiate(AICharcter, spawnLocation.position, Quaternion.identity);
    }

 
}
