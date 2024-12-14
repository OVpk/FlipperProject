using UnityEngine;

public class DrumBumper : MonoBehaviour
{
    public float strength;
    [SerializeField] private Animation anim;
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 force = (collision.transform.position - transform.position).normalized * strength;
        collision.rigidbody.AddForce(force);
        anim.Play("DrumBumper Bump");
    }
}
