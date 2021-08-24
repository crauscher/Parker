using UnityEngine;
using UnityEngine.Events;

public class MessageEventListener : MonoBehaviour
{
    // config variables
    public MessageEvent mEvent;
    public UnityEvent<string> Response;
    
    //public method
    public void OnEventRaised(string text) {Response?.Invoke(text);}
    
    // private methods
    private void OnEnable() {mEvent?.RegisterListener(this);}
    private void OnDisable() {mEvent?.UnRegisterListener(this);}
}
