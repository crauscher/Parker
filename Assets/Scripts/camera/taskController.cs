using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskController : MonoBehaviour
{
    // config params
    [SerializeField] private List<Task> tasks = new List<Task>();

    // state variables
    [SerializeField] private int currentTask;
    [SerializeField] private bool noMoreTasks;
    [SerializeField] private int keyNumber;

    // cached references

    private void Awake()
    {
        noMoreTasks = false;
    }

    private void Start() 
    {
        currentTask = 1;
        TaskNumberScript.task = currentTask;  // Display on HUD
        TaskNumberScript.taskCount = tasks.Count;
        TaskNumberScript.taskString = "aaa";
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

        TaskNumberScript.task = currentTask; // Display on HUD
        TaskNumberScript.taskCount = tasks.Count;
       // TaskNumberScript.taskString = tasks[currentTask].taskText;
    }



    public int GetKeyNumber() { 
        keyNumber = tasks[currentTask].GetKeyNumber();
        KeyNumberScript.key = keyNumber;  // Display on HUD
        return keyNumber; 
    }
}
