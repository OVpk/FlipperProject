using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    
    public Animation anim;
    private string animName;
    public float strength = 1;
    private Vector3 force;

    public enum KeyPossibility
    {
        L2,
        R2
    }
    
    public KeyPossibility choiceKey;

    private string inputAxisName;

    private void Start()
    {
        switch (choiceKey)
        {
            case KeyPossibility.L2 : 
                force = new Vector3(1,1,0) * strength;
                inputAxisName = "L2";
                animName = "StickLeft";
                break;
            case KeyPossibility.R2 : 
                force = new Vector3(-1,1,0) * strength;
                inputAxisName = "R2";
                animName = "StickRight";
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        other.GetComponent<Rigidbody>().AddForce(force);
    }

    // Update is called once per frame
    void Update()
        {
            float axisValue = 0f;
        
            axisValue = Input.GetAxis(inputAxisName);
            
            if (axisValue > 0.1f)
            {
                anim.Play(animName);
            }
    
        }
}
