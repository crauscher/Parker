using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButtonScript : MonoBehaviour 
{
    public Button UpdateButton;
    private taskController tc;  

    // Start is called before the first frame update
    void Start()
    {
        Button btn = UpdateButton.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
        tc = FindObjectOfType<taskController>();
    }

    public void OnButtonPress() {

        CarsRemainingScript.currentCarsRemaining--;  // Updates the number of cars to go
              // TipsScript.Tips += 5;  
        tc.SetNextTask();

    }

    void TaskOnClick(){
       
    }
}
