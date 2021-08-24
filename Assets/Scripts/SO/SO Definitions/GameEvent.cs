using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="new GameEvent")]
public class GameEvent : ScriptableObject
{
    // config variable
    private List<GameEventListener> listeners = new List<GameEventListener>();

    // public methods
    public void RegisterListener(GameEventListener listener) {listeners.Add(listener);}
    public void UnRegisterListener(GameEventListener listener) {listeners.Remove(listener);}
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }
}
