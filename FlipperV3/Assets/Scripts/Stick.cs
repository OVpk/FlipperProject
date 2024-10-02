using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public KeyCode key;
    public Animation anim;
    
    // Update is called once per frame
    void Update()
        {
            if (Input.GetKey(key))
            {
                anim.Play("StickLeft");
                anim.Play("StickRight");
            }
    
        }
}
