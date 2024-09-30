using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float     decal;
    public float     accel;
    public float     loadingSpeed = 1;
    public KeyCode   key          = KeyCode.Space;
    public Rigidbody rb;

    void Update()
    {
        if (Input.GetKeyUp(key))
        {
            rb.isKinematic = false;
        }
        
        if (Input.GetKey(key))
        {
            rb.isKinematic = false;

            if (transform.localPosition.y > decal)
            {
                rb.velocity += -transform.up * loadingSpeed;
            }
            else
            {
                rb.velocity    = Vector3.zero;
                rb.isKinematic = true;
            }
        }
        else
        {
            if (transform.localPosition.y < 0)
            {
                rb.velocity    += transform.up * accel;
            }
            else
            {
                rb.isKinematic          = true;
                transform.localPosition = Vector3.zero;
            }
        }

        transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
    }
}