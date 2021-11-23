using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    
    public void OnButtonPress() {

        // (timer automatically restarts)
        
        LevelScript.currentLevel = 1;   // This will update the Level number
        CarsRemainingScript.currentCarsRemaining = 4;  // Updates the number of cars to go
        GoalScript.currentGoal = "Space A33";  // Set the next goal
        TipsScript.Tips = 0;  // Zero out tips

        SceneManager.LoadScene("Level-01");  // Reload the first level (which will also mute sound)
    }
    
}
