using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenEffect : MonoBehaviour
{
    public Material postEffect;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, postEffect);
    }
}
