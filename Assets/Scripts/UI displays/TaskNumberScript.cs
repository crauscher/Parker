using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskNumberScript : MonoBehaviour
{

    Text TaskDisplay;
    public int taskNumber;
    public int taskCount;
    public string taskString;
    public int taskDestination = 777;
    public int taskTime;
    public int taskPayout;


    // Start is called before the first frame update
    void Start()
    {
        TaskDisplay = GetComponent<Text> ();
    }

    // Update is called once per frame
    // Most of these values are set in taskController.cs
    void Update()
    {

        TaskDisplay.text = ("Task " + taskNumber + " of " + taskCount + "\n" +
                            "Title: " + taskString + "\n" +
                            "Dest slot: " + taskDestination + "\n" +
                            "Task Time: " + taskTime + " seconds\n" +
                            "Payout: $" + taskPayout
        
        );
    }
}
