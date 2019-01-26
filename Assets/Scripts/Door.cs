using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Lock
{
    public bool opened;

    private Animator anim;

    private void Awake()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    public override bool Interact(HoldableObject carryingObject, PlayerInteraction playerInteraction)
    {
        if (locked)
        {
            if (base.Interact(carryingObject, playerInteraction))
            {
                Open();
                return true;
            }
            else
            {
                return false;
            }
            
        }
        else
        {
            if (opened) {
                Close();
            } else
            {
                Open();
            }
            return true;
        }
    }

    private void Open()
    {
        opened = true;
        anim.SetTrigger("Open");
        // call open animation
    }

    private void Close()
    {
        opened = false;
        anim.SetTrigger("Close");
        // call close  animation
    }

}
