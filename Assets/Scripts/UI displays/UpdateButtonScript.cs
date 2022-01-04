using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButtonScript : MonoBehaviour 
{
        public Button UpdateButton;
        private taskController tc;
        
    public void OnButtonPress() {

    CarsRemainingScript.currentCarsRemaining--;  // Updates the number of cars to go
   // TipsScript.Tips += 5;  // Increase tips by some amount
    tc.SetNextTask();

    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn = UpdateButton.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
            tc = FindObjectOfType<taskController>();
    }

    void TaskOnClick(){
        //Debug.Log ("The button has been clicked!");
    }
}
