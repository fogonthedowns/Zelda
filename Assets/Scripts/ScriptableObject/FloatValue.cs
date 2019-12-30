using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// allows us to create as an object with right click
[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {

    }
}
