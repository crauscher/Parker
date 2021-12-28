using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
   public static string timeString = "00:00";
   public static float timeLeft;
   public static Text timeDisplay;
   public bool isMute = false;
   //private GameObject attendant;

    // Start is called before the first frame update
    void Start()
    {
        timeDisplay = GetComponent<Text>();   
        timeDisplay.color = Color.green;
        timeDisplay.text = timeString;

        timeLeft = 45.0f;   // 45 seconds by default at start
				

    }

    void Update()        // Update is called once per frame
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
                    
            float minutes = Mathf.Floor(timeLeft/60);
            float seconds = Mathf.RoundToInt(timeLeft % 60);

            // format time as text
            timeString = Float2Text(minutes) + ":" + Float2Text(seconds);

                                                                           // warning mode
            if (minutes < 1)
            {
                timeDisplay.color = Color.red; 
                if (seconds > 0)
                {
                    timeDisplay.fontSize=50;
                    timeDisplay.text = "Oh nooooooz! \n Hurry Hurry! \n" + timeString;
                } else
                {
                    if (CarsRemainingScript.currentCarsRemaining > 0) {
                        timeDisplay.fontSize=100;
            
                        timeDisplay.text = "Time's up :(";

                            // If driving  (how do we tell if they are driving car or not?)

                                // Return car  - What is the location of the first car? Does it need a tag?

                                    // Is the "parked" car different from the driveable car? If so:
                                        // Destroy(this.gameObject);  // Get rid of the driveable car

                                       // VehicleSensor.AwakenAttendant(); (replicating code here rather than calling)
                                // AwakenAttendant();
                                //      fc.SetFocus(attendant.gameObject);    (is this line needed?)

                                // Find Attendant game object, setActive, move to Start


                            // If not driving
                         
                                //attendant = GameObject.FindGameObjectWithTag("Attendant");   // Find the Attendant game object 

                                //attendant.SetActive(true); 

                               // attendant.gameObject.GetComponent<ItemFocus>().ParkSelf();  // Zaps attendant back to start

                                                    
                            // Other stuff

                           TipsScript.Tips -= 5; // Will check for zero later

                    }
                }
            }
            else  // One minute or more remaining
            {
            
                timeDisplay.color = Color.green; 
                timeDisplay.text = timeString;
            }   
        }
        else  // timeLeft is at zero
        {
            if (CarsRemainingScript.currentCarsRemaining < 1) {  // All cars found on this level
                timeDisplay.text = timeString;                 // display the final time, but without "Oh nooooz!"
            }
            
            Debug.Log("Time is at zero...");
            timeLeft = 0;
        }
    }

    private string Float2Text(float num)
    {
        if (num < 10.0f)
        {
            return "0" + num.ToString();
        }
        else
        {
            return num.ToString();
        }
    }
}
