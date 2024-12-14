using UnityEngine;

public class Propulsor : MonoBehaviour
{
    [SerializeField] private Animation animation;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private AudioSource audioSource;
    
    public Vector3 angle;
    public float strength;

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        animation.Play("ballPool");
    }
    
    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.transform.position = spawnPoint.transform.position;
        other.gameObject.GetComponent<Rigidbody>().AddForce(angle * strength);
    }
}
