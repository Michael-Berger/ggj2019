using System;
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


    public void LightToggle()
    {
        if (hasBulb && (lightSwitch == null  || lightSwitch.switchIsOn))
        {
            LightOn();
            
        }
        else
        {
            LightOff();
        }
    }

    private void LightOn()
    {
        light.enabled = true;
        material.EnableKeyword("_EMISSION");
    }

    private void LightOff()
    {
        light.enabled = false;
        material.DisableKeyword("_EMISSION");
    }

    public void ForceOn()
    {
        LightOn();
    }

    public void ForceOff()
    {
        LightOff();
    }

    public void ResetForcedLights()
    {
        LightToggle();
    }




}
