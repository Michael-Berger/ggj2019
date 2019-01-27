using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeDoor : Interactable
{
    private bool open = false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        ToggleOpen();

        return true;
    }

    private void ToggleOpen()
    {
        if (open)
        {
            open = false;
            animator.SetTrigger("Close");
        }
        else
        {
            open = true;
            animator.SetTrigger("Open");
        }
    }

    public void CrackOpenDoorAfterDelay(float delay)
    {
        StartCoroutine(_CrackOpenDoorAfterDelay(delay));
    }

    private IEnumerator _CrackOpenDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!open)
        {
            animator.SetTrigger("Crack Open");
        }
    }
}
