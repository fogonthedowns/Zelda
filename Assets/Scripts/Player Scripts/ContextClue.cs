using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    // This is the Context Clue Game Object
    // set up under player
    public GameObject contextClue;
    public bool contextActive = false;

    public void Toggle()
    {
        contextActive = !contextActive;
        if (contextActive)
        {
            contextClue.SetActive(true);
        } else
        {
            contextClue.SetActive(false);
        }
        // toogle the contextActive
        
    }
}
