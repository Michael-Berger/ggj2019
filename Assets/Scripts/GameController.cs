using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject reticle;
    public CanvasGroup splash;
    public MeshRenderer lanternRenderer;
    //private Material laternMaterial;
    private Color laternEmissiveColor;

    private float splashTime = 2f;
    private float splashFadeTime = 1f;
    private float lightFadeTime = 1f;
    
    void Awake()
    {
        reticle.SetActive(false);
        splash.gameObject.SetActive(true);
        laternEmissiveColor = lanternRenderer.material.GetColor("_EmissionColor");
        lanternRenderer.material.SetColor("_EmissionColor", laternEmissiveColor * 0);
        lanternRenderer.GetComponentInChildren<Light>().intensity = 0;
        StartCoroutine(Splash());
    }

    private IEnumerator Splash()
    {
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
            splash.alpha = Mathf.Lerp(1, 0, timer / splashFadeTime);
            yield return null;
        }

        timer = 0;

        while (timer < lightFadeTime)
        {
            timer += Time.deltaTime;
            lanternRenderer.material.SetColor("_EmissionColor", laternEmissiveColor * Mathf.Lerp(0, 1, timer / lightFadeTime));
            lanternRenderer.GetComponentInChildren<Light>().intensity = Mathf.Lerp(0, 1, timer / lightFadeTime);

            yield return null;
        }



        reticle.SetActive(true);
        splash.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
