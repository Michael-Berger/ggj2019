using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : Interactable
{

    public delegate void KeyHandler(string code);
    public event KeyHandler KeyPressed;

    public string key;

    private Material material;

    private readonly float pressTime = 0.15f;

    private bool pressing = false;

    private Vector3 pressedPosition;


    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        material.SetColor("_EmissionColor", Color.white);
        pressedPosition = transform.localPosition;
        pressedPosition.z = 0.0116f;
    }


    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        if (!pressing && carryingObject == null)
        {
            StartCoroutine(PressKey());
            return true;
        }
        else
        {
            return false;
        }
    }


    IEnumerator PressKey()
    {
        pressing = true;

        material.EnableKeyword("_EMISSION");

        float timer = pressTime;


        Vector3 defaultPosition = transform.localPosition;


        while (timer > 0)
        {
            timer -= Time.deltaTime;
            transform.localPosition = Vector3.Lerp(pressedPosition, defaultPosition, timer / pressTime); // these are backwards on purpose
            yield return null;
        }

        timer = pressTime;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            transform.localPosition = Vector3.Lerp(defaultPosition, pressedPosition, timer / pressTime);
            yield return null;
        }


        pressing = false;

        material.DisableKeyword("_EMISSION");

        KeyPressed?.Invoke(key);
        

    }
}
