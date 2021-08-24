using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    // config variables
    public GameEvent gEvent;
    public UnityEvent Response;

    // public method
    public void OnEventRaised() {Response?.Invoke();}

    // private methods
    private void OnEnable() {gEvent?.RegisterListener(this);}
    private void OnDisable() { gEvent?.UnRegisterListener(this); }
}
