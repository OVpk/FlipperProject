using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public Animation anim;
    private void OnTriggerEnter(Collider other)
    {
        anim.Play("moving");
    }
    
}
