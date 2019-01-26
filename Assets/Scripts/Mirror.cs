using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interactable
{
    public Mirror counterpart;

    private GameObject cameraObject;
    private Camera mirrorCamera;
    private RenderTexture texture;

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
        cameraObject.AddComponent<Camera>();
        cameraObject.transform.parent = transform;
        cameraObject.transform.localRotation *= Quaternion.Euler(-90, 180, 0);
        cameraObject.transform.position = mesh.bounds.center;

        mirrorCamera = GetComponentInChildren<Camera>();
        mirrorCamera.targetDisplay = 2;
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
        Quaternion mainCameraRotation = Camera.main.transform.rotation;
        mainCameraRotation *= Quaternion.Euler(0, 180, 0);
        mirrorCamera.transform.rotation = mainCameraRotation;
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
