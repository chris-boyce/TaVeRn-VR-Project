using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCheck : MonoBehaviour
{
    private MissionController missionController;
    public SignFliping signflip;
    void Start()
    {
        missionController = GetComponent<MissionController>();
    }
    public void RunCheck()
    {
        if(signflip.isOpen)
        {
            missionController.CompleteMission(MissionController.Mission.FlipSign);
        } 
    }

}
