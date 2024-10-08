using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLink : MonoBehaviour
{
    public int score = 0;
    public Trigger trigger;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (gameObject.tag == "DrumLogoTag" && trigger.drumActive) 
        {
            score += 10;
            trigger.drumActive = false;
            Destroy(trigger.objetActuel);
        }

        
    }
}
