﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public delegate void WorldTransition(bool inMirrorWorld);

    public static event WorldTransition Transitioned;

    public AudioSource fakeWorldAudio;

    [NonSerialized]
    public HoldableObject carryingObject;
    public Transform carryPosition;

    private Rigidbody carryBody;

    private LayerMask interactMask;
    private int originalCarryLayer;

    public static bool InMirrorWorld { get; set; } = false;


    private void Awake()
    {
        carryBody = new GameObject().AddComponent<Rigidbody>();
        carryBody.isKinematic = true;
        carryBody.name = "Carry Anchor";
        interactMask = ~LayerMask.GetMask("CarriedObject");
    }

    private void FixedUpdate()
    {
        carryBody.MovePosition(carryPosition.position);
        carryBody.MoveRotation(carryPosition.rotation);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f, interactMask))
            {
                HoldableObject ho = hit.transform.GetComponent<HoldableObject>();

                if (ho != null && ho != carryingObject)
                {
                    StartCoroutine(CarryObject(ho));
                    return;
                }

                Interactable interactable = hit.transform.GetComponent<Interactable>();


                if (interactable != null && interactable.Interact(carryingObject, this))
                {
                    return;
                }

                

            }



            if (carryingObject != null)
            {
                Drop();
            }
            else
            {

            }
        }


    }

    public void Drop(bool destroy = false)
    {
        carryingObject.gameObject.layer = originalCarryLayer;
        // Todo determine if we can just check top level for these components
        //carryingObject.GetComponent<Rigidbody>().isKinematic = false;
        //carryingObject.GetComponentInChildren<Collider>().enabled = true;

        if (destroy)
        {
            Destroy(carryingObject.gameObject);
        }

        carryingObject = null;
    }


    IEnumerator CarryObject(HoldableObject ho)
    {

        carryingObject = ho;

        originalCarryLayer = carryingObject.gameObject.layer;

        carryingObject.gameObject.layer = LayerMask.NameToLayer("CarriedObject");

        Rigidbody rb = carryingObject.GetComponent<Rigidbody>();


        //rb.isKinematic = true;
        //carryingObject.GetComponentInChildren<Collider>().enabled = false;
        //carryingObject.transform.parent = carryPosition;
        carryingObject.transform.position = carryPosition.position;


        SpringJoint joint = carryingObject.gameObject.AddComponent<SpringJoint>();


        joint.spring = 500f;

        joint.connectedBody = carryBody;
        

        while (carryingObject != null)
        {
            yield return null;
        }

        

        Destroy(joint);

        //rb.isKinematic = false;
    }


    public void TransitionWorlds()
    {
        InMirrorWorld = !InMirrorWorld;

        if (InMirrorWorld)
        {
            fakeWorldAudio.Play();
        } else
        {
            fakeWorldAudio.Stop();
        }

        Transitioned?.Invoke(InMirrorWorld);
        GetComponentInChildren<FullScreenEffect>().enabled = InMirrorWorld;
        
    }



}
