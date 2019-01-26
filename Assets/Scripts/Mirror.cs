using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interactable
{
    public Mirror counterpart;

    private GameObject cameraObject;
    private Camera mirrorCamera;
    private RenderTexture texture;

    Quaternion counterpartDeltaRotation;

    private void Awake()
    {
        if (counterpart == null) {
            counterpart = this;
        }

        MeshRenderer mesh = GetComponent<MeshRenderer>();

        texture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);

        Material material = GetComponent<Renderer>().material;
        material.mainTexture = texture;

        cameraObject = new GameObject();
        cameraObject.name = "Camera";
        cameraObject.AddComponent<Camera>();
        cameraObject.transform.parent = transform;
        cameraObject.transform.position = mesh.bounds.center;

        cameraObject.transform.rotation = Quaternion.LookRotation(transform.up, transform.forward);
        
        mirrorCamera = GetComponentInChildren<Camera>();
        mirrorCamera.targetDisplay = 2;
        
        counterpartDeltaRotation = counterpart.transform.rotation * Quaternion.Inverse(transform.rotation);

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
        cameraObject.transform.rotation = counterpartDeltaRotation * Quaternion.LookRotation(Camera.main.transform.forward);
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
