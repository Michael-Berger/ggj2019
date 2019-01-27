using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingScreen : MonoBehaviour
{

    private float blinkTime = 2f;
    private float timer = 0;
    private bool screenActive = true;

    private Material material;

    private new Light light;



    private void Transitioned(bool inMirrorWorld) => SetScreenActive(screenActive);

    private void Awake()
    {
        PlayerInteraction.Transitioned += Transitioned;
        material = GetComponent<MeshRenderer>().material;
        light = GetComponentInChildren<Light>();
    }
    

    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > blinkTime)
        {
            SetScreenActive(screenActive = !screenActive);
            timer = 0;

        }

    }


    private void SetScreenActive(bool active)
    {
        if (active || PlayerInteraction.InMirrorWorld)
        {
            material.DisableKeyword("_EMISSION");
            if (light != null)
            {
                light.enabled = false;
            }
        }
        else
        {
            material.EnableKeyword("_EMISSION");
            if (light != null)
            {
                light.enabled = true;
            }
        }
    }


    



}
