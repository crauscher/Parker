using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskNumberScript : MonoBehaviour
{

    Text TaskDisplay;
    public static int task = -99;
    public static int taskCount = -99;
    public static string taskString = "nada";

    // Start is called before the first frame update
    void Start()
    {
        TaskDisplay = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        TaskDisplay.text = ("Task " + task + " of " + taskCount + "\n" +
                            "Title: " + taskString + "\n" +
                            "Dest slot: " + "\n" +
                            "Task Time: " + "\n" +
                            "Payout: $" 
        
        );
    }
}
