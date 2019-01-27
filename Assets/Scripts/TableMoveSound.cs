using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMoveSound : MonoBehaviour
{
    public AudioSource key;
    public AudioSource table;
    public AudioSource thud;

    public void PlayKey()
    {
        key.Play();
    }

    public void PlayTable()
    {
        table.Play();
    }

    public void PlayThud()
    {
        thud.Play();
    }
}
