using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Task")]
public class TaskCreator : ScriptableObject
{
    // config parameters
    [SerializeField] string taskText;
    [SerializeField] int taskTime;
    [SerializeField] int taskPayout;
    [SerializeField] bool taskComplete;

    [Header("Fetch")]
    [SerializeField] int keyNum;
    [Header("Destination")]
    [SerializeField] int destinationSlot;

    // public methods
    public string GetTaskText() { return taskText; }
    public int GetTaskTime() { return taskTime; }
    public int GetTaskPayout() { return taskPayout; }
    public void MarkTaskComplete() { taskComplete = true; }
    public bool CheckTaskComplete() { return taskComplete; }
    public int GetKeyNumber() { return keyNum; }
    public int GetDestinationSlot() { return destinationSlot; }
}
