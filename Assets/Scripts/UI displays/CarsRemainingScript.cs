using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarsRemainingScript : MonoBehaviour
{

    Text CarsDisplay;
    private taskController tc;

    public static int currentCarsRemaining = 6;

    // Start is called before the first frame update
    void Start()
    {
        CarsDisplay = GetComponent<Text> ();
        tc = FindObjectOfType<taskController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCarsRemaining <= 0) {
            CarsDisplay.text = "You found them all, good job!";
        } else if (currentCarsRemaining == 1)
        {
            CarsDisplay.text = "Only 1 more car to go!";
        }
        else {
             CarsDisplay.text = "Hey! You have " + currentCarsRemaining + " more cars to go!";
        }
    }

    
 
}
