using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Goes on Game Object
public class SignalListener : MonoBehaviour
{
    public Signal_Event msgSignal;
    public UnityEvent signalEvent;

    // Does something when we raise the signal.
    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }

    // When this object gets created
    // Go to the signal, and register
    private void OnEnable()
    {
        msgSignal.RegisterListener(this);
    }

    // so we are not taking up memory
    private void OnDisable()
    {
        msgSignal.DeRegisterListener(this);
    }
}
