﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFixture : Interactable
{
    public bool hasBulb;


    public LightSwitch lightSwitch;

    private new Light light;
    private Material material;

    public void Awake()
    {
        light = GetComponentInChildren<Light>();
        material = new Material(GetComponent<MeshRenderer>().material);

        GetComponent<MeshRenderer>().material = material;

        if (lightSwitch != null)
        {
            lightSwitch.Switched += Switched;
        }
        LightToggle();
    }

    private void Switched(bool turnedOn) => LightToggle();

    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {

        if (hasBulb)
        {
            return false;
        }

        if (carryingObject is LightBulb)
        {
            playerInteraction.Drop(true);
            hasBulb = true;
            LightToggle();
            return true;
        }
        return false;
    }


    private void LightToggle()
    {
        if (hasBulb && (lightSwitch == null  || lightSwitch.switchIsOn))
        {
            // light on
            light.enabled = true;
            material.EnableKeyword("_EMISSION");
        }
        else
        {
            // light off
            light.enabled = false;
            material.DisableKeyword("_EMISSION");
        }
    }


}
