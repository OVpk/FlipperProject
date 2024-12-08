using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToSong : MonoBehaviour
{
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }

    private void OnCollisionEnter(Collision other)
    {
        audioSource.Play();
    }
}
