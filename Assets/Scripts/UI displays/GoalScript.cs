using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
     Text GoalDisplay;

    public static string currentGoal = "A3";

    // Start is called before the first frame update
    void Start()
    {
        GoalDisplay = GetComponent<Text> ();   
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGoal == "A3")
        {
            //GoalDisplay.text = "You're looking for a car\n in A3, go go go!";
            GoalDisplay.text = "Next goal: " + currentGoal;
        }
        else {
             GoalDisplay.text = "Next goal: " + currentGoal;
        }
    }
}


