using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObject : Interactable
{

    private bool canBePickedUp;
    private bool isBeingHeld;

    // Start is called before the first frame update
    void Start()
    {
        canBePickedUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Highlight()
    {
        // Highlight the object to make it obvious that you can pick it up.
    }

    void Pickup()
    {
        canBePickedUp = false;
        isBeingHeld = true;
    }

    void Drop()
    {
        canBePickedUp = true;
        isBeingHeld = false;
    }

    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        return base.Interact(carryingObject,playerInteraction);
    }

}
