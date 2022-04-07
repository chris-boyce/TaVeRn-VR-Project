using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkCheck : MonoBehaviour
{

    private MissionController missionController;
    private void Start()
    {
        missionController = GetComponent<MissionController>();
    }
    public void HasCompleted()
    {
        missionController.CompleteMission(MissionController.Mission.ServeDrink);
    }

}
