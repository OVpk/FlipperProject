using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RailLoopScript : MonoBehaviour
{

    public GameObject startAnimPosition;

    public GameObject ball;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        ball = other.GameObject();
        
        other.transform.parent.position = startAnimPosition.transform.position;
        
        
        other.transform.parent.GetChild(1).GameObject().SetActive(true);
        
        other.GetComponent<Animation>().Play("BallInRail");

        
        
        //other.transform.parent.GetChild(1).GameObject().SetActive(false);
    }
    
    
}
