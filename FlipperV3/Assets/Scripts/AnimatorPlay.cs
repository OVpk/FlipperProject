using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlay : MonoBehaviour
{

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator.Play("ComboGIFanimation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
