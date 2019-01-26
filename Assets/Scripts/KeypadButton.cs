using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : Interactable
{

    public delegate void KeyHandler(string code);
    public event KeyHandler KeyPressed;

    public string key;


    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        if (carryingObject == null)
        {
            KeyPressed?.Invoke(key);
            return true;
        }
        else
        {
            return false;
        }
    }
}
