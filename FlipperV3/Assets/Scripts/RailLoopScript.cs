using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RailLoopScript : MonoBehaviour
{

    public GameObject startAnimPosition;

    
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
        other.transform.parent.position = startAnimPosition.transform.position;
        other.GetComponent<Animation>().Play("BallInRail");
    }
}
