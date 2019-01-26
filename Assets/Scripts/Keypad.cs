using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public delegate void LockHandler();

    public event LockHandler Unlocked;
    
    public string keyCode;

    private string currentSequence;

    private bool locked = true;

    private void Awake()
    {
        foreach (KeypadButton keypadButton in GetComponentsInChildren<KeypadButton>())
        {
            keypadButton.KeyPressed += ButtonPressed;
        }
    }


    private void ButtonPressed(string key)
    {
        if (!locked)
        {
            return;
        }

        if (keyCode.Substring(currentSequence.Length, 1) == key)
        {
            currentSequence += key;
            if (currentSequence == keyCode)
            {
                Unlocked?.Invoke();
                locked = false;
            }
        }
        else
        {
            currentSequence = "";
        }
    }


}
