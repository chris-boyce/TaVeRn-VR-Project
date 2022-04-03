using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CandleCheck : MonoBehaviour
{
    private GameObject[] Wixs;
    private MissionController missionController;
    private bool isFinshed;

    void Start()
    {
        Wixs = GameObject.FindGameObjectsWithTag("Ignite");
        missionController = GetComponent<MissionController>();
    }
    public void RunCheck()
    {
        Debug.Log("Run Check");
        for (int i = 0; i < Wixs.Length; i++)
        {
            if(Wixs[i].GetComponent<IgniteObject>().isLit == false)
            {
                Debug.Log("Not Finished");
                isFinshed = false;
            }
            else
            {
                isFinshed = true;
            }
        }
        if(isFinshed)
        {
            Debug.Log("Running Completed Objective");
            missionController.CompleteMission(MissionController.Mission.LightCandles);
        }

    }

}
