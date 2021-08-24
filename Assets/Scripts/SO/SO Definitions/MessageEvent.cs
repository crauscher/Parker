using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="new MessageEvent")]
public class MessageEvent : ScriptableObject
{
    // config variable
    private List<MessageEventListener> listeners = new List<MessageEventListener>();

    // public methods
    public virtual void RegisterListener(MessageEventListener listener) {listeners.Add(listener);}
    public virtual void UnRegisterListener(MessageEventListener listener) {listeners.Remove(listener);}
    public virtual void Raise(string text)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(text);
        }
    }
}
