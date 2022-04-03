using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionController : MonoBehaviour
{
    public enum Mission { LightCandles, FlipSign, ServeDrink , NullMission };
    private Mission currentMission;
    public Dictionary<Mission, bool> Missions = new Dictionary<Mission, bool>();
    public AIController AIController;
    public TextMeshProUGUI BlackboardText;

    void Start()
    {
        //Adds To Dictionary
        Missions.Add(Mission.LightCandles, false);
        Missions.Add(Mission.FlipSign, false);
        Missions.Add(Mission.ServeDrink, false);
        Missions.Add(Mission.NullMission, false);
        //Sets Current Mission
        currentMission = Mission.LightCandles;
        Debug.Log("New Mission = " + currentMission);
        AIController.SpawnAI();
        UpdateSwitch();
    }

    public bool CompleteMission(Mission completedMission)
    {
        if (currentMission == completedMission)//If Mission is Completed and it is the target mission
        {
            Missions[completedMission] = true; //Sets the mission true in the dictionary
            Debug.Log("Completed " + (completedMission) + " SetValue " + Missions[Mission.LightCandles]);

            foreach(KeyValuePair<Mission, bool> keyValue in Missions) //Goes Through the Dictionary
            {
                if(keyValue.Key == Mission.NullMission) //If the read through the dictionary reaches the bottom
                {
                    currentMission = Mission.NullMission; //Sets on no mission
                    break;
                }
                if(keyValue.Value == false) //If the Read through the dictionary and the mission is false sets that to the current mission
                {
                    currentMission = keyValue.Key;
                    break;
                }
                
            }
            UpdateSwitch();
            Debug.Log("New Mission = "  + currentMission);
            return true; // Returns True if mission is changed
        }
        return false;  
    }
    void UpdateSwitch()
    {
        switch(currentMission)
        {
            case Mission.LightCandles:
                BlackboardText.text = "Light The Candles Around The Bar!";
                break;
            case Mission.FlipSign:
                BlackboardText.text = "Flip Sign to Open Bar";
                break;
            case Mission.ServeDrink:
                BlackboardText.text = "Server A Drink To The Customer";
                break;
            case Mission.NullMission:
                BlackboardText.text = "Error Message Out Of Missions";
                break;
        }
        
    }
}


