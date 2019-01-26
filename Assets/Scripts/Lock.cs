using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Interactable
{
    public string keyCode;

    public bool locked;

    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        if (carryingObject is Key && ((Key)carryingObject).keyCode == keyCode)
        {
            playerInteraction.Drop(true);
            locked = false;
            return true;
        }
        else
        {
            return false;
        }
    }



}
