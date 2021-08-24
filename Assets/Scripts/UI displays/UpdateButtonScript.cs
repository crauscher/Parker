using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButtonScript : MonoBehaviour 
{
        public Button UpdateButton;
 
 public void OnButtonPress(){
        LevelScript.currentLevel++;   // This will update the Level number
        CarsRemainingScript.currentCarsRemaining--;  // Updates the number of cars to go
        GoalScript.currentGoal = "return to start";  // Set the next goal
        TipsScript.Tips += 5;  // Increase tips by some amount
 }

    // Start is called before the first frame update
    void Start()
    {
        Button btn = UpdateButton.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        //Debug.Log ("The button has been clicked!");
    }
}
