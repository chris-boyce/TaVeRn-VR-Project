using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    public enum AIActions { GetToChair, ScanForDrink, ConsumeDrink, ScanForFood, ConsumeFood, Waiting , Leave, Destroy };
    private AIActions m_AIAction;
    private bool HasDrink;
    private NavMeshAgent agent;
    private GameObject[] chairs;
    public Transform HandSpot;
    public GameObject Drink;
    private GameObject transformPoint;
    private bool StopScan = false;

    private void Update()
    {
        if (transformPoint != null && StopScan == false)
        {
            transform.LookAt( new Vector3 (transformPoint.transform.position.x , transform.position.y, transformPoint.transform.position.z), Vector3.up);
            DrinkScan();
        }
    }

    void Awake()
    {
        chairs = GameObject.FindGameObjectsWithTag("Chair");
        agent = GetComponent<NavMeshAgent>();
        UpdateAIAction(AIActions.GetToChair);
    }
    public void UpdateAIAction(AIActions QueAction)
    {
        m_AIAction = QueAction;
        switch(m_AIAction)
        {
            case AIActions.GetToChair:
                WalkTo(chairs[0].transform.position);
                break;
            case AIActions.ScanForDrink:
                DrinkScan();
                break;
            case AIActions.ConsumeDrink:
                ConsumeDrink();
                break;
        }
    }
    void WalkTo(Vector3 WalkToPosition)
    {
        agent.SetDestination(WalkToPosition);
        StartCoroutine(WaitToBeAtSeat(10f));
    }
    IEnumerator WaitToBeAtSeat(float WaitTime)//Change to Distence Check
    {
        yield return new WaitForSeconds(WaitTime);
        UpdateAIAction(AIActions.ScanForDrink);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if(other.transform.tag == "AttachPoints")
        {
           transformPoint = other.gameObject;
        }
    }
    void DrinkScan()
    {

         if(transformPoint.GetComponent<XRExclusiveSocketInteractor>().Help != null)
         {
               
               if(transformPoint.GetComponent<XRExclusiveSocketInteractor>().Help.GetComponent<MugController>().isFull == true)
               {
                    Drink = transformPoint.transform.GetComponent<XRExclusiveSocketInteractor>().Help.gameObject;
                    Debug.Log("Drink has yes");
                    HasDrink = true;
               }

         }
        
        if(HasDrink == true)
        {
            UpdateAIAction(AIActions.ConsumeDrink);
        }
    }
    void ConsumeDrink()
    {
        StopScan = true;
        Debug.Log("WE HAVE MADE IT");
        StartCoroutine(WaitToDrink(5f));
    }
    IEnumerator WaitToDrink(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        Drink.GetComponent<MugController>().EmptyCup();
        transformPoint.transform.GetComponent<XRExclusiveSocketInteractor>().Help = null;
    }



}
