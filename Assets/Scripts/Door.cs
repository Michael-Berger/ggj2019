using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Lock
{
    public bool opened;

    private Animator anim;

    public AudioSource soundDoorOpen;
    public AudioSource soundDoorClose;
    public AudioSource soundDoorLocked;

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
                soundDoorLocked.Play();
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

    public void Open()
    {
        opened = true;
        anim.SetTrigger("Open");
        soundDoorOpen.Play();
        // call open animation
    }

    public void Close()
    {
        opened = false;
        anim.SetTrigger("Close");
        soundDoorClose.Play();
        // call close  animation
    }

}
