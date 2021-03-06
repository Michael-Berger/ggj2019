﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintScreen : MonoBehaviour
{


    private Material material;
    public Renderer displayWhenVisibleRenderer;

    private new Light light;

    void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        material.DisableKeyword("_EMISSION");
        PlayerInteraction.Transitioned += Transitioned;
        light = GetComponentInChildren<Light>();
        light.enabled = false;
    }

    private void Transitioned(bool inMirrorWorld)
    {
        if (inMirrorWorld)
        {
            StartCoroutine(WaitToShow());
        }
        PlayerInteraction.Transitioned -= Transitioned;
    }

    private IEnumerator WaitToShow()
    {
        yield return null;
        while (!displayWhenVisibleRenderer.IsVisibleFrom(Camera.main))
        {
            yield return null;
        }
        
        material.EnableKeyword("_EMISSION");
        light.enabled = true;
    }

}
