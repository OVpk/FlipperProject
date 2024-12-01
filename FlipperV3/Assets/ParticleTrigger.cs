using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem launchParticle;

    private void OnTriggerEnter(Collider other)
    {
        launchParticle.Play();
    }
}
