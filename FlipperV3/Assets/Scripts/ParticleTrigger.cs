using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem launchParticle;

    private void OnTriggerEnter(Collider other)
    {
        launchParticle.Play();
    }
}
