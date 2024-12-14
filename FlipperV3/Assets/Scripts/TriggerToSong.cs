using UnityEngine;

public class TriggerToSong : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }
    private void OnCollisionEnter(Collision other)
    {
        audioSource.Play();
    }
}
