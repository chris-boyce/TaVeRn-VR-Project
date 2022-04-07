using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class AINavigation : MonoBehaviour
{
    public enum AIActions { GetToChair, ScanForDrink, ConsumeDrink, ScanForFood, ConsumeFood, Waiting , Leave, Destroy };
    private AIActions m_AIAction;
    private bool HasDrink;
    private NavMeshAgent agent;
    public GameObject chair;
    public Transform HandSpot;
    public Transform LeavePos;
    public GameObject Meat;
    public GameObject Drink;
    public GameObject Plate;
    private GameObject transformPoint;
    public XRExclusiveSocketInteractor PlateXRSocket;
    public XRExclusiveSocketInteractor Socket;
    public AIController _AIController;
    bool StopScan = false;
 
    private void Update()
    {
 
        if (Socket != null && StopScan == false && Socket.Help != null)
        {

            if (Socket.Help.tag == "Mug" && m_AIAction == AIActions.ScanForDrink)
            {
                DrinkScan();
            }
            else if (Socket.Help.tag == "Plate" && m_AIAction == AIActions.ScanForFood)//If on table there is a plate
            {
                FoodScan();
            }

        }
        
    }

    void Awake()
    {
        _AIController = GameObject.Find("AIController").GetComponent<AIController>();
        for (int i = 0, len = _AIController.chairAllocation.Length; i < len; i++)
        {
            if(_AIController.chairAllocation[i].isFilled == false)
            {
                chair = _AIController.chairAllocation[i].Chair;
                _AIController.chairAllocation[i].isFilled = true;
                break;
            }
           
        }
            
        //chairs = GameObject.FindGameObjectsWithTag("Chair");
        LeavePos = GameObject.Find("LeavePos").transform;
        agent = GetComponent<NavMeshAgent>();
        UpdateAIAction(AIActions.GetToChair);
    }
    public void UpdateAIAction(AIActions QueAction)
    {
        m_AIAction = QueAction;
        switch(m_AIAction)
        {
            case AIActions.GetToChair:
                Debug.Log(gameObject.name + "Is Going To Chair");
                WalkTo(chair.transform.position);
                break;
            case AIActions.ScanForDrink:
                Debug.Log(gameObject.name + "Scaning For Drink");
                Socket = chair.GetComponentInChildren<XRExclusiveSocketInteractor>();
                break;
            case AIActions.ConsumeDrink:
                Debug.Log(gameObject.name + "Has Drunk");
                Socket.Help = null;
                ConsumeDrink();
                break;
            case AIActions.ScanForFood:
                Debug.Log(gameObject.name + "Is Scanning For Food");
                StopScan = false;
                break;
            case AIActions.ConsumeFood:
                Debug.Log(gameObject.name + "Eaten Food");
                StopScan = true;
                ConsumeFood();
                break;
            case AIActions.Waiting:
                Debug.Log(gameObject.name + "Is Waiting To Leave");
                StartCoroutine(WaitToLeave(5f));
                break;
            case AIActions.Leave:
                break;
            case AIActions.Destroy:
                Debug.Log(gameObject.name + "Is Destroied");
                Destroy(gameObject);
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

    void DrinkScan()
    {
         if(Socket.Help.GetComponent<MugController>().isFull == true)
         {
            StopScan = true;
            Drink = Socket.Help.gameObject;
            HasDrink = true;
         }

        if(HasDrink == true)
        {
            UpdateAIAction(AIActions.ConsumeDrink);

        }
    }
    void ConsumeDrink()
    {
        StartCoroutine(WaitToDrink(5f));
    }
    IEnumerator WaitToDrink(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        Drink.GetComponent<MugController>().EmptyCup();
        Drink = null;
        UpdateAIAction(AIActions.ScanForFood);
    }
    void FoodScan()
    {
        Plate = Socket.Help.gameObject;
        PlateXRSocket = Plate.GetComponentInChildren<XRExclusiveSocketInteractor>();
        Meat = Plate.GetComponentInChildren<MeatChecker>().Meat;

        if (Meat != null) //If plate isnt null
        {
            StopScan = true;
            UpdateAIAction(AIActions.ConsumeFood);
        }

    }
    void ConsumeFood()
    {
        StartCoroutine(WaitToEat(5f));
    }

    IEnumerator WaitToEat(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);

        Meat.transform.position = (new Vector3(100, 100, 100));
        Meat.GetComponent<SocketTarget>().SocketType = "EatenFood";
        PlateXRSocket.ClearHelp();
        PlateXRSocket = null;
        Plate = null;
        UpdateAIAction(AIActions.Waiting);

    }
    IEnumerator WaitToLeave(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        agent.SetDestination(LeavePos.position);
        yield return new WaitForSeconds(10f);
        UpdateAIAction(AIActions.Destroy);
    }






}
