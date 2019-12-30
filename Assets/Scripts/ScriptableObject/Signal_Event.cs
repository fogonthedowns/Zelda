using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal_Event : ScriptableObject
{
    // creates list
    public List<SignalListener> listeners = new List<SignalListener>();


    // Goes throught the list of listeners backwards
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            // whatever it needs to do
            // do
            listeners[i].OnSignalRaised();
        }
    }

    // adds to the list
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    // removes from list
    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
