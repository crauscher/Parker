using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitParkingLot : MonoBehaviour
{

     private string message;
    [SerializeField] private GameObject hud;            // canvas panel object
    private HUDController hc;                           // controller script

     // Start is called before the first frame update
    void Start()
    {
     //   hud = GameObject.Find("HUD");
     //     hc = hud.GetComponent<"HUDController">();

     //  hc = hud.GetComponent<HUDController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Found the exit!");

        // Some of this is being prototyped in VehicleSensor.cs
      
       // hc.AddMessageToQueue("Found the exit, congrats!");
       // hc.AddMessageToQueue("You earned $5 in tips!");
       //  hc.AddMessageToQueue("Next goal: B7");
      
        CarsRemainingScript.currentCarsRemaining--;  // Updates the number of cars to go
        TipsScript.Tips += 5;  // Increase tips by some amount


        TimerScript.timeDisplay.color = Color.green;
        
        TimerScript.timeLeft = 90.0f;
        TimerScript.timeDisplay.fontSize=150;
    }
}
