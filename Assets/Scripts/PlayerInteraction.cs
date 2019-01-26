using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private HoldableObject carryingObject;
    public Transform carryPosition;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                HoldableObject ho = hit.transform.GetComponent<HoldableObject>();

                if (ho != null)
                {
                    ho.GetComponentInChildren<Rigidbody>().isKinematic = true;
                    ho.GetComponentInChildren<Collider>().enabled = false;
                    ho.transform.parent = carryPosition;
                    ho.transform.localPosition = Vector3.zero;

                    carryingObject = ho;

                    //StartCoroutine(CarryObject());
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
                carryingObject.transform.parent = null;
                // Todo determine if we can just check top level for these components
                carryingObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
                carryingObject.GetComponentInChildren<Collider>().enabled = true;

                carryingObject = null;
            }
            else
            {

            }
        }


    }

    IEnumerator CarryObject()
    {

        Rigidbody rb = carryingObject.GetComponentInChildren<Rigidbody>();
        rb.isKinematic = true;
        
        

        while (carryingObject != null)
        {
            // rb.AddForce((carryPosition.position - carryingObject.transform.position).normalized * 20f);


            yield return null;
        }
        rb.isKinematic = false;
    }


}
