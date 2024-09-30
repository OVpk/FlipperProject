using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumBumper : MonoBehaviour
{
    public float strength = 1;
    public Animation anim;
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 force = (collision.transform.position - transform.position).normalized * strength;
        collision.rigidbody.AddForce(force);
        anim.Play("DrumBumper Bump");
    }
}