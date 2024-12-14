using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    public void PlaySystem()
    {
        particle.Play();
    }
}
