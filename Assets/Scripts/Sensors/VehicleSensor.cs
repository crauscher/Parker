using UnityEngine;

public class VehicleSensor : MonoBehaviour
{
    // config params
    public GameEvent ge_AtDestination, ge_Collision;
    public GameEvent ge_Started, ge_Stopped;

    // state variables

    // cached references
    private HUDController hc;

    private void Awake()
    {
        hc = FindObjectOfType<HUDController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Exit")  // Car is colliding with Exit, so it has been returned
        {
            ge_AtDestination?.Raise(); // If game event "At Destination" is not null, raise (broadcast) event
                                       // HUD Controller == add message to queue "Vehicle is returned to owner. Congratulations..."
                                       // HUD Controller == add message to queue "Ready for another one?"
                                       // Main Camera == SetNextTask (in Task Controller)
                                       // Station == AwakenAttendant (in StationSensor)
                                       // ** NEED TO ADD Timer Reset

            Destroy(this.gameObject);  // Get rid of the car
        
            if (CarsRemainingScript.currentCarsRemaining > 1) {
                 CarsRemainingScript.currentCarsRemaining--;  // Updates the number of cars to go
                 GoalScript.currentGoal = "Space A34?";  // Set the next goal
                 TipsScript.Tips += 27;  // Add tips (junk value for now, will be more specific later)
                 TimerScript.timeLeft = 107f;
            }
            else {
                CarsRemainingScript.currentCarsRemaining = 0;
                hc.AddMessageToQueue("You've cleared all the keys on this level, good job!");
                TimerScript.timeLeft = 0f;
            }
        }
    }
}
