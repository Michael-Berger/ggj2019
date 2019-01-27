using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject reticle;
    public CanvasGroup splash;
    //public MeshRenderer lanternRenderer;
    public Glowstick glowstick;
    //private Material laternMaterial;
    private Color laternEmissiveColor;

    private float splashTime = 8f;
    private float splashFadeTime = 1f;
    private float lightFadeTime = 1f;
    
    void Awake()
    {
        reticle.SetActive(false);
        splash.gameObject.SetActive(true);
        
        StartCoroutine(Splash());
    }

    private IEnumerator Splash()
    {
        yield return null;
        glowstick.FadeOut(0);

        float timer = 0;

        while (timer < splashTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0;

        while (timer < splashFadeTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        glowstick.FadeIn(lightFadeTime);

    }
}
