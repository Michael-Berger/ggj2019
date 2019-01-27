using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSwitch : Interactable
{

    public UnityEvent SwitchedOn;
    public UnityEvent SwitchedOff;

    public bool switchIsOn;


    public void Awake()
    {

        if (switchIsOn)
        {
            SwitchedOn?.Invoke();
        }
        else
        {
            SwitchedOff?.Invoke();
        }

    }


    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {

        if (switchIsOn = !switchIsOn)
        {
            SwitchedOn?.Invoke();
        }
        else
        {
            SwitchedOff?.Invoke();
        }

        return true;
    }
}
