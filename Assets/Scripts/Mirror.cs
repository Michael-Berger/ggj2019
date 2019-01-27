using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interactable
{
    public Mirror counterpart;

    public delegate void TransitionHandler();
    public event TransitionHandler Teleported;


    private GameObject cameraObject;
    [System.NonSerialized]
    public Camera mirrorCamera;
    private RenderTexture texture;

    private new Renderer renderer;

    Quaternion counterpartDeltaRotation;

    private void Awake()
    {
        if (counterpart == null) {
            counterpart = this;
        }

        MeshRenderer mesh = GetComponent<MeshRenderer>();

        texture = new RenderTexture(512, 512, 16, RenderTextureFormat.ARGB32);

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


        renderer = GetComponent<MeshRenderer>();

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
        counterpart.mirrorCamera.enabled = renderer.IsVisibleFrom(Camera.main);

        if (counterpartDeltaRotation == Quaternion.identity)
        {

            Vector3 inverted = Vector3.up * Vector3.Dot(-Camera.main.transform.forward, Vector3.up);


            cameraObject.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward - 2* inverted);
        }
        else
        {
            cameraObject.transform.rotation = counterpartDeltaRotation * Quaternion.LookRotation(Camera.main.transform.forward);
        }

        
    }

    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        TeleportPlayerToCounterpart(playerInteraction);
        return true;
    }

    void TeleportPlayerToCounterpart(PlayerInteraction playerInteraction)
    {
        Vector3 relativePositionToThis = transform.InverseTransformPoint(playerInteraction.transform.position);
        Vector3 newPosition = counterpart.transform.TransformPoint(relativePositionToThis);
        playerInteraction.transform.position = newPosition;
        //playerInteraction.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().mouseLook.TurnAround();


        if (playerInteraction.carryingObject != null)
        {
            relativePositionToThis = transform.InverseTransformPoint(playerInteraction.carryingObject.transform.position);
            newPosition = counterpart.transform.TransformPoint(relativePositionToThis);
            playerInteraction.carryingObject.transform.position = newPosition;
        }

        playerInteraction.TransitionWorlds();

        Teleported?.Invoke();

    }

}
