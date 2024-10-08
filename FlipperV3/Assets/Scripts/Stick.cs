using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public KeyCode key;
    public Animation anim;
    public float strength = 1;
    private Vector3 force;

    public string check;
    private void OnCollisionEnter(Collision collision)
    {
        if (key == KeyCode.Mouse0)
        {
            force = new Vector3(1,1,0) * strength;
        }
        else
        {
            force = new Vector3(-1,1,0) * strength;
        }
        collision.rigidbody.AddForce(force);
    }

    // Update is called once per frame
    void Update()
        {
            if (Input.GetKey(key))
            {
                if (check == "Left")
                {
                    anim.Play("StickLeft");
                }
                else
                {
                    anim.Play("StickRight");
                }
            }
    
        }
}
