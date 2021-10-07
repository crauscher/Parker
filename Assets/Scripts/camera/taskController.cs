﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskController : MonoBehaviour
{
    // config params
    [SerializeField] private List<Task> tasks = new List<Task>();
    [SerializeField] private GameObject TN_object;      // object that has the task number script on it
    private TaskNumberScript TN_Script;                 // reference to the task number script

    // The above list can be seen (I think) in Scripts/SO/Tasks
    // The task definitions are in Scripts/SO/SO Definitions/Task.cs

    // state variables
    [SerializeField] private int currentTask;
    [SerializeField] private bool noMoreTasks;
    [SerializeField] private int keyNumber;

    // cached references

    private void Awake()
    {
        noMoreTasks = false;
        TN_Script = TN_object.GetComponent<TaskNumberScript>();     // when game first starts, grab a reference to the script from the object
    }

    private void Start() 
    {
        currentTask = 1; // Hard coding for now

        TN_Script.taskNumber = currentTask;  // Display on HUD
        TN_Script.taskCount = tasks.Count;
        TN_Script.taskString = tasks[currentTask].GetTaskText();
      //  TaskNumberScript.taskString = tasks[0].taskText;
    }

    // private methods

    // public methods
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
            currentTask = 0;
            noMoreTasks = true;
        }

        TN_Script.taskNumber = currentTask; // Display on HUD

        TN_Script.taskCount = tasks.Count;

       // TaskNumberScript.taskString = tasks[currentTask].taskText;
    }



    public int GetKeyNumber() { 
        keyNumber = tasks[currentTask].GetKeyNumber();
        KeyNumberScript.key = keyNumber;  // Display on HUD
        return keyNumber; 
    }
}
