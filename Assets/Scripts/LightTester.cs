using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTester : MonoBehaviour
{
    private bool lightsOn = false;
    LightFixture[] fixtures;

    // Start is called before the first frame update
    void Awake()
    {
        fixtures = FindObjectsOfType<LightFixture>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && lightsOn)
        {
            TurnOffLights();
        }
        else if (Input.GetKeyDown(KeyCode.L) && !lightsOn)
        {
            TurnOnLights();
        }
    }

    void TurnOnLights()
    {
        lightsOn = true;
        foreach(LightFixture lf in fixtures)
        {
            lf.LightToggle();
        }
    }

    void TurnOffLights()
    {
        lightsOn = false;
        foreach (LightFixture lf in fixtures)
        {
            lf.LightToggle();
        }
    }
}
