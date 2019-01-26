using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{

    public delegate void SwitchHandler(bool turnedOn);
    public event SwitchHandler Switched;

    public bool switchIsOn;


    public void Awake()
    {
        Switched?.Invoke(switchIsOn);
    }


    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        Switched?.Invoke(switchIsOn = !switchIsOn);
        return true;
    }
}
