using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public bool drumActive = false;

    public GameObject objetActuel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DrumLogoTag")
        {
            drumActive = true;
        }

        objetActuel = other.gameObject;

    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "DrumLogoTag")
        {
            drumActive = false;
            Destroy(other.gameObject);
        }
            
    }
}
