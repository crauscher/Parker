using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendantSensor : MonoBehaviour
{
    // config params
    public GameEvent ge_RightVehicle, ge_WrongVehicle, ge_PressedKeyfob;

    // state variables
    [SerializeField] private int carkey,carlock = 0;
    [SerializeField] private bool hasKey, foundTarget = false;
    private ItemFocus target;
    private GameObject itemHit;
    private Animator anim;

    public GameObject[] vehicles;                           // Array of objects that have the "vehicle" tag
    public GameObject possibleCar;


    // cached references
    [SerializeField] private ObjectValue CamFocus;
    private taskController tc;
    private HUDController hc;

    private void Awake()
    {
        tc = FindObjectOfType<taskController>();
        hc = FindObjectOfType<HUDController>();

  
            vehicles = GameObject.FindGameObjectsWithTag("Vehicle"); // Make an array of all possible vehicles

    }
    void Update() 
    {
        if (!hasKey)
        {
            GetCarKey();
        }
    }

    // private methods
    private void GetCarKey()                                // Gets the key number of the vehicle you want to find
    {
        carkey = tc.GetKeyNumber();                         // Run method on TaskController script
        if (carkey > 0)
        {
            hasKey = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hasKey)
        {
            itemHit = other.gameObject;
            foundTarget = CheckFoundTarget(itemHit);        // checks if item hit has a key lock (or at least an ItemID)
        }
        else
        {
            foundTarget = false;                            // you don't have a key, so you don't have a target to find
        }
                
        if (foundTarget)
        {

            CheckKeyFitsLock(itemHit);                             // you found a key lock, so check if it matches your key
        }

        // Need an "else" here for if player doesn't have a key or the collided item doesn't have a key lock
     }

    private bool CheckFoundTarget(GameObject itemHit)
    {
        var _focus = itemHit.GetComponent<ItemFocus>();
        if (_focus)
        {
            carlock = _focus.GetItemID();                   // The carlock is the collided object's itemID
            return true;
        }
        else
        {
            carlock = 0;
            return false;
        }
    }


    private void CheckKeyFitsLock(GameObject carHit)
    {
        ToggleVehicleLights(carHit);         // Whichever car was hit, right or wrong, make it flash

        if (carlock == carkey)              // Carkey is from the current task.  carlock is from the collided object's itemID                          
        {
            ge_RightVehicle?.Raise();       // Tell the rest of the game that the right vehicle was found
            FoundRightCar();
        }
        else
        {
            ge_WrongVehicle?.Raise();       // Tell the rest of the game that the wrong vehicle was found
            FoundWrongCar();                // Display message to player about how it's the wrong car

  

            // Add code here to make the correct vehicle's lights flash
            // Hardcode itemID associated with correct car?
            // To start, the player is in Task 1, with Key #2, and they are looking for the car with itemID 2 (from slotID2)
            // If we have gotten to this point, we should make itemID #2 car's lights flash
            // How to find the car?
            // Set its anim bool isFlashing to true
        }
    }
    private void FoundRightCar() 
    {
        hasKey = false;
        hc.AddMessageToQueue("You found the right car!");                                           // send message "Found it!"
        itemHit.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        CamFocus.SetValue(itemHit.gameObject);                                                      // swap focus to vehicle
        this.gameObject.SetActive(false);                                                           // deactivate attendant
        GoalScript.currentGoal = "Take car to exit.";
    }
    private void FoundWrongCar()
    {
        hc.AddMessageToQueue("Your key doesn't work on this car! The car you want is in " + 
            GoalScript.currentGoal + ".");     

            

    }





    // You should call this function with a keypress (like "Spacebar") when you want the lights to flash or turn off.
    // It expects you to pass in a reference to the vehicle object (like "itemHit") and accesses its Animator component.
    // It then checks the light's current status (flashing/off) and sets them to the other state.
    //
    // It DOES NOT verify whether or not you have the right key -- that check is done elsewhere -- nor does it check if you are
    // close to the vehicle.
    private void ToggleVehicleLights(GameObject vehicle)
    {
        Animator vehicleAnim = vehicle.gameObject.GetComponent<Animator>();    // Can we turn lights on by touching any car? 
                                                                                // How do we tell it's even a car?
        var _focus = vehicle.GetComponent<ItemFocus>();
        var carNumber = _focus.GetItemID();

        Debug.Log("Trying to toggle lights on vehicle # " + carNumber + ".");  

        if (!vehicleAnim.GetBool("isFlashing"))
        {
            vehicleAnim.SetBool("isFlashing", true);
        }
        else
        {
            vehicleAnim.SetBool("isFlashing", false);
        }
    }
}