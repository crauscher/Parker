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
        CarsRemainingScript.currentCarsRemaining = 6;  // Updates the number of cars to go
        TipsScript.Tips = 0;  // Zero out tips (does this need to be zeroed since we're
                              //                      loading a new scene anyway?)

        SceneManager.LoadScene("Level-01");  // Reload the first level (which will also mute sound)
    }
    
}
