using UnityEngine;

public class StationSensor : MonoBehaviour
{
    // config variables
    public GameEvent ge_OnDuty, ge_CheckIn;
    public GameEvent ge_AddKey, ge_RemoveKey, ge_LastKey, ge_NoMoreKeys;

    // state variables

    // cached references
    private GameObject attendant;
    private HUDController hc;
    [SerializeField] private ObjectValue CamFocus;

    private void Start()
    {
        attendant = GameObject.FindGameObjectWithTag("Attendant");
        hc = FindObjectOfType<HUDController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag =="Attendant")    // The attendant has collided with the parking station
        {
           
            hc.AddMessageToQueue("You have a key, go find the right car!");

                                        // Here's a new key, go find the <person's> car, it's in <section>"
                                        // You've already got a key, you need to find that car before you can get another.
                                        //   As a reminder, you are looking for <person's> car in <section>"
                                        //     If I have to remind you again, you are going to lose your tips!"
                                        //
                                        // You've found all the cars on this level, Congrats!" (send to win screen)
           
           // ge_CheckIn?.Raise();        // if there is a game event "Check In", then raise (broadcast) the event.

                                        // (One of the) listener(s) is on the HUD object which responds by
                                        //   adding a message to the queue from the object.
                                        //     For example, if it hears the event "AttendantCheckIn", it sends
                                        //       the message, "Hey, where are the keys" to the queue.
                                        //
                                        // Further code needed:
                                        //
                                        //   Find out if the player has a key in hand or not
                                        //
                                        // * Only go to ge_CheckIn if the player is actually checking a car in (as opposed to running into it randomly)
                                        // * Handle other possible events:
                                        // ** OnDuty
                                        // ** Add Key
                                        // ** Remove Key
                                        // ** Last Key
                                        // ** No More Keys
                                        // ** CamFocus

            // AwakenAttendant
        }
    }

    public void AwakenAttendant()     // This code appears to be completely unused???
    {
        //ge_OnDuty?.Raise();
        attendant.SetActive(true);
        attendant.gameObject.GetComponent<ItemFocus>().ParkSelf();
        CamFocus.SetValue(attendant.gameObject);
    }
}
