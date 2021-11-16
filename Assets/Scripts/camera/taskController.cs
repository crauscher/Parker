﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskController : MonoBehaviour
{
    // config params
    [SerializeField] private List<Task> tasks = new List<Task>();
    [SerializeField] private GameObject TN_object;      // object that has the task number script on it
  //  [SerializeField] private GameObject Goal_object;
    private TaskNumberScript TN_Script;                 // reference to the task number script
//    private GoalScript Goal_Script;

    // The above list can be seen in Scripts/SO/Tasks. Tasks must be created there as objects, and also
    //   added as elements to the Task Controller script object on the Main Camera by dragging them from
    //   ../SO/Tasks to the Tasks array.
    // The task field definitions are in Scripts/SO/SO Definitions/Task.cs

    // state variables
    [SerializeField] public int currentTask;
    [SerializeField] private bool noMoreTasks;
    [SerializeField] private int keyNumber;

    // cached references

    private void Awake()
    {
        noMoreTasks = false;
        TN_Script = TN_object.GetComponent<TaskNumberScript>();     // when game first starts, grab a reference to the script from the object
       // Goal_Script = Goal_object.GetComponent<GoalScript>();
    }

    private void Start() 
    {
        currentTask = 0; // Hard coding for now
        DisplayTaskInfo();
    }

    public void SetNextTask()
    {
        tasks[currentTask].SetTaskComplete();
        Debug.Log("TaskController: Setting task #" + currentTask + " complete."); // Might be better in task.cs

        if (currentTask<(tasks.Count-1) && !noMoreTasks)
        {
            currentTask++;
        }
        else 
        {
            noMoreTasks = true;
        }
        DisplayTaskInfo();
    }

    public int GetKeyNumber() { 
        keyNumber = tasks[currentTask].GetKeyNumber();
        KeyNumberScript.key = keyNumber;  // Display on HUD
        return keyNumber; 
    }

    public void DisplayTaskInfo() {
        
        TN_Script.taskNumber = currentTask + 1;  // Display on HUD
        TN_Script.taskCount = tasks.Count;
        TN_Script.taskString = tasks[currentTask].GetTaskText();
        TN_Script.taskDestination = tasks[currentTask].GetdestinationSlot();
        TN_Script.taskTime = tasks[currentTask].GetTaskTime();
        TN_Script.taskPayout = tasks[currentTask].GetTaskPayout();
        TN_Script.taskSectionSlot = tasks[currentTask].GetSectionSlot();
    }

}
