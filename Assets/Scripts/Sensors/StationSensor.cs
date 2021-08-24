using UnityEngine;

public class StationSensor : MonoBehaviour
{
    // config variables
    public GameEvent ge_OnDuty, ge_CheckIn;
    public GameEvent ge_AddKey, ge_RemoveKey, ge_LastKey, ge_NoMoreKeys;

    // state variables

    // cached references
    private GameObject attendant;
    [SerializeField] private ObjectValue CamFocus;

    private void Start()
    {
        attendant = GameObject.FindGameObjectWithTag("Attendant");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="Attendant")    // The attendant has collided with the parking station
        {
            ge_CheckIn?.Raise();        // if there is a game event "Check In", then raise (broadcast) the event.
            // AwakenAttendant
        }
    }

    public void AwakenAttendant()
    {
        //ge_OnDuty?.Raise();
        attendant.SetActive(true);
        attendant.gameObject.GetComponent<ItemFocus>().ParkSelf();
        CamFocus.SetValue(attendant.gameObject);
    }
}
