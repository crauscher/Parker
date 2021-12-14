using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public Text GoalDisplay;

    public static string currentGoal = "Snazzy!";   // This may be redundant with "destination"

    // Start is called before the first frame update
    void Start()
    {
        GoalDisplay = GetComponent<Text> ();   
     //   currentGoal.text="Somewhere";
    }

    // Update is called once per frames
    void Update()
    {
        GoalDisplay.text = "Goal: " + currentGoal;  // Set in several other scripts such as VehicleSensor.cs,
                                                         //    UpdateButtonScript.cs and UIManager.cs
    }
}


