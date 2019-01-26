using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interactable
{
    public Mirror counterpart;
    
    private Camera mirrorCamera;
    private RenderTexture texture;

    private void Awake()
    {
        texture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);

        Material material = GetComponent<Renderer>().material;
        material.mainTexture = texture;

        mirrorCamera = GetComponentInChildren<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mirrorCamera.targetTexture = counterpart.texture;
        texture.Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        TeleportPlayerToCounterpart(playerInteraction);
        return true;
    }

    void TeleportPlayerToCounterpart(PlayerInteraction playerInteraction)
    {
        Vector3 relativePositionToThis = playerInteraction.transform.InverseTransformPoint(transform.position);
        Vector3 newPosition = counterpart.transform.TransformPoint(relativePositionToThis);
        playerInteraction.transform.position = newPosition;
        playerInteraction.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().mouseLook.TurnAround();
    }

}
