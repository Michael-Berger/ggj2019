using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFixture : Interactable
{
    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        return carryingObject is LightBulb;
    }
}
