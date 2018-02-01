using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewGameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    public void Raise()
    {
        for (int i = listeners.Count -1; i >= 0; i--) 
        {
            listeners[i].OnEventRaised();
        }
    }
    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        } else
        {
            Debug.LogWarning("Listener re-registered to an event.");
        }
    }
    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
