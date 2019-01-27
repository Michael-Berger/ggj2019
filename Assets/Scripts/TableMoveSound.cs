using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMoveSound : MonoBehaviour
{
    public AudioSource key;
    public AudioSource table;

    public void PlayKey()
    {
        key.Play();
    }

    public void PlayTable()
    {
        table.Play();
    }
}
