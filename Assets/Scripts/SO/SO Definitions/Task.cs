using UnityEngine;

[CreateAssetMenu(menuName="new Task")]
public class Task : ScriptableObject
{
    // config parameters
    [SerializeField] string taskText;

    [Header("Fetch")]
    [SerializeField] int keyNum;
    [SerializeField] int originSlot;

    [Header("Destination")]
    [SerializeField] int destinationSlot;
    [SerializeField] string taskSectionSlot = "QQ";
    [SerializeField] int taskTime;
    [SerializeField] int taskPayout;

    // public method
    public void SetTaskComplete() {
        // Below line is currently handled in taskController
  //      Debug.Log("Task.cs: Setting task #" + taskController.currentTask + " complete.");  
    }

    // There appears to be some duplication here between public methods in task.cs and TaskCreator.cs

    public int GetKeyNumber() { return keyNum; }
    public string GetTaskText() { return taskText; }
    public int GetdestinationSlot() { return destinationSlot; }
    public int GetTaskTime() { return taskTime; }
    public int GetTaskPayout() { return taskPayout; }
    public string GetSectionSlot() { return taskSectionSlot; }
}
