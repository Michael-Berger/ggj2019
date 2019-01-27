using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowstick : HoldableObject
{

    private Color emissiveColor;
    private MeshRenderer meshRenderer;

    private bool fadeInComplete = false;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        emissiveColor = meshRenderer.material.GetColor("_EmissionColor");
        FadeOut(0);
    }


    public void FadeOut(float time)
    {
        StartCoroutine(_Fade(time, 1, 0));
    }

    public void FadeIn(float time)
    {
        StartCoroutine(_Fade(time, 0, 1));
        fadeInComplete = true;
    }

    IEnumerator _Fade(float time, float start, float target)
    {
        float timer = 0;

        while (timer <= time)
        {
            timer += Time.deltaTime;
            meshRenderer.material.SetColor("_EmissionColor", emissiveColor * Mathf.Lerp(start, target, timer / time));
            meshRenderer.GetComponentInChildren<Light>().intensity = Mathf.Lerp(start, target, timer / time);

            yield return null;
        }
    }

    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        if (!fadeInComplete)
        {
            FadeIn(1.0f);
        }
        
        
        return base.Interact(carryingObject, playerInteraction);
    }


    //void OnGUI()
    //{


    //    if (GUI.Button(new Rect(10, 10, 50, 50), "FadeIn"))
    //        FadeIn(1.0f);

    //    if (GUI.Button(new Rect(10, 70, 50, 30), "FadeOut"))
    //        FadeOut(1.0f);
    //}



}
