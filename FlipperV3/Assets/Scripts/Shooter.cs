using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float decal;
    public float accel;
    public float loadingSpeed = 1;
    public Rigidbody rb;

    void Update()
    {
        bool isDPadPressed = Mathf.Approximately(Input.GetAxis("DPadVertical"), -1f);

        if (isDPadPressed)
        {
            rb.isKinematic = false;

            if (transform.localPosition.y > decal)
            {
                if (!rb.isKinematic)
                {
                    rb.velocity += -transform.up * loadingSpeed;
                }
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
        else
        {
            if (transform.localPosition.y < 0)
            {
                rb.isKinematic = false;
                rb.velocity += transform.up * accel;
            }
            else
            {
                rb.isKinematic = true;
                transform.localPosition = Vector3.zero;
            }
        }

        transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
    }
}