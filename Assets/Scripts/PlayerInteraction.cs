using System;
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

    private float defaultFoV;


    private void Awake()
    {
        carryBody = new GameObject().AddComponent<Rigidbody>();
        carryBody.isKinematic = true;
        carryBody.name = "Carry Anchor";
        interactMask = ~LayerMask.GetMask("CarriedObject");
        defaultFoV = Camera.main.fieldOfView;
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

                if (ho != null && ho != carryingObject && carryingObject == null && ho.Interact(null, this))
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
        StartCoroutine(TransitioningSequence());
    }


    IEnumerator TransitioningSequence()
    {
        float timer = 0;
        float shrinkTime = 0.15f;
        float growTime = 0.25f;


        while (timer < shrinkTime)
        {
            timer += Time.deltaTime;
            Camera.main.fieldOfView = Mathf.Lerp(defaultFoV, 60, timer / shrinkTime);// Spring(defaultFoV, 140, timer / shrinkTime);
            yield return null;
        }
        timer = 0;

        while (timer < growTime)
        {
            timer += Time.deltaTime;
            Camera.main.fieldOfView = Mathf.Lerp(60, defaultFoV, timer / growTime); //Spring(140, defaultFoV, timer / growTime);
            yield return null;
        }
        
    }



    //public static float Spring(float start, float end, float value)
    //{
    //    value = Mathf.Clamp01(value);
    //    value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
    //    return start + (end - start) * value;
    //}



}
