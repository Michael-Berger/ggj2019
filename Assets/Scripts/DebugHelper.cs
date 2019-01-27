using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ForcedSetting
{
    None,
    On,
    Off
}

public class DebugHelper : MonoBehaviour
{
    private ForcedSetting lightsForced;
    LightFixture[] fixtures;

    // Start is called before the first frame update
    void Awake()
    {
        fixtures = FindObjectsOfType<LightFixture>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.L))
        {
            //  Cycle lights
            switch (lightsForced)
            {
                case ForcedSetting.None:
                    foreach (LightFixture f in fixtures)
                    {
                        f.ForceOn();
                    }
                    lightsForced = ForcedSetting.On;
                    break;
                case ForcedSetting.On:
                    foreach (LightFixture f in fixtures)
                    {
                        f.ForceOff();
                    }
                    lightsForced = ForcedSetting.Off;
                    break;

                case ForcedSetting.Off:
                    foreach (LightFixture f in fixtures)
                    {
                        f.ResetForcedLights();
                    }
                    lightsForced = ForcedSetting.None;
                    break;
            }

        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            foreach (Door door in FindObjectsOfType<Door>())
            {
                door.Open();
            }
        }

#endif

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.F5)){
            SceneManager.LoadScene("House");
        }




    }

}
