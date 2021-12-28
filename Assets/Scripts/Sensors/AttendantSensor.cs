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


    // cached references
    [SerializeField] private ObjectValue CamFocus;
    private taskController tc;
    private HUDController hc;

    private void Awake()
    {
        tc = FindObjectOfType<taskController>();
        hc = FindObjectOfType<HUDController>();
        
    }
    void Update() 
    {
        if (!hasKey)
        {
            GetCarKey();
        }
    }

    // private methods
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hasKey)
        {
            itemHit = other.gameObject;
            foundTarget = CheckFoundTarget(itemHit);
        }
        else
        {
            foundTarget = false;
        }
                
        if (foundTarget)
        {
            CheckKeyFitsLock();
        }
     }
    private void GetCarKey()            // Gets the key number that the player is currently carrying (?)
    {
        carkey = tc.GetKeyNumber();     // Run method on TaskController script
        if (carkey > 0)
        {
            hasKey = true;
        }
    }
    private bool CheckFoundTarget(GameObject itemHit)
    {
        var _focus = itemHit.GetComponent<ItemFocus>();
        if (_focus)
        {
            carlock = _focus.GetItemID();
            return true;
        }
        else
        {
            carlock = 0;
            return false;
        }
    }
    private void CheckKeyFitsLock()
    {
        if (carlock == carkey)                                  
        {
            ge_RightVehicle?.Raise();
            FoundRightCar();
        }
        else
        {
            ge_WrongVehicle?.Raise();
            FoundWrongCar();
        }
    }
    private void FoundRightCar() 
    {
        hasKey = false;
        hc.AddMessageToQueue("You found the right car!");          // send message "Found it!"
        itemHit.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        CamFocus.SetValue(itemHit.gameObject);      // swap focus to vehicle
        this.gameObject.SetActive(false);           // deactivate attendant
        GoalScript.currentGoal = "Take car to exit.";
    }
    private void FoundWrongCar()
    {
        hc.AddMessageToQueue("Your key doesn't work on this car! The car you want is in " + 
            GoalScript.currentGoal + "."); // send message "Wrong key."

            // Add code here to make the correct vehicle's lights flash
    }
}