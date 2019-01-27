using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInTheBasementSequence : MonoBehaviour
{

    public Mirror sequenceStartMirror;

    public LightFixture[] lightFixtures;
    public Collider blockedPasasageCollider;

    private new MeshRenderer renderer;
    
    void Awake()
    {
        sequenceStartMirror.Teleported += Teleported;
        renderer = GetComponent<MeshRenderer>();
    }

    private void Teleported() => StartCoroutine(StartSequence());

    private IEnumerator StartSequence()
    {
        while (!renderer.IsVisibleFrom(Camera.main))
        {
            yield return null;
        }
        renderer.material.EnableKeyword("_EMISSION");

        GetComponentInChildren<Light>().enabled = true;

        while (renderer.IsVisibleFrom(Camera.main))
        {
            yield return null;
        }

        foreach (LightFixture fixture in lightFixtures)
        {

            fixture.hasBulb = true;
            fixture.LightToggle();
        }


        blockedPasasageCollider.isTrigger = true;


    }

}
