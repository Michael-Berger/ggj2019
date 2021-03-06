﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomMirrorChange : MonoBehaviour
{
    public Mirror newCounterpart;
    public Keypad keypad;
    public Door door;
    public Glowstick glowstick;
    public LightFixture lightFixture;
    public Glowstick skeletonGlowstick;

    private void Awake() => keypad.Unlocked += Unlocked;

    private void Unlocked() {

        GetComponent<Mirror>().counterpart = newCounterpart;
        newCounterpart.mirrorCamera.targetTexture = GetComponent<Mirror>().texture;
        door.locked = false;
        door.Open();
        glowstick.FadeIn(1);
        skeletonGlowstick.FadeIn(1);
        lightFixture.hasBulb = true;
        lightFixture.LightToggle();
    }

}
