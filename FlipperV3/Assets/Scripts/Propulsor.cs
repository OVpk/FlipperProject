using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsor : MonoBehaviour
{

    public Vector3 angle;
    public float strength;

    public Animation animation;

    public GameObject spawnPoint;

    public AudioSource audioSource;

    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.transform.position = spawnPoint.transform.position;
        other.gameObject.GetComponent<Rigidbody>().AddForce(angle * strength);
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        animation.Play("ballPool");
    }
}
