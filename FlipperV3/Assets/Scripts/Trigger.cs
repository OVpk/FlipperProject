using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float life = 100;

    public GameObject objetActuel;
    
    public Dictionary<string, bool> dictInstrumentState = new Dictionary<string, bool>
    {
        {"Drum", false}
    };
    
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
        for (int i = 0; i < dictInstrumentState.Count; i++)
        {
            string key = dictInstrumentState.ElementAt(i).Key;
            
            if (other.gameObject.tag == key + "LogoTag")
            {
                dictInstrumentState[key] = true;
            }
        }
        objetActuel = other.gameObject;
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        for (int i = 0; i < dictInstrumentState.Count; i++)
        {
            string key = dictInstrumentState.ElementAt(i).Key;
            
            if (other.gameObject.tag == key + "LogoTag")
            {
                if (dictInstrumentState[key])
                {
                    life = EditLife(life, -20f);
                }
                dictInstrumentState[key] = false;
                Destroy(other.gameObject);
            }
        }
    }

    public float EditLife(float currentLife, float addedNumber)
    {
        currentLife += addedNumber;
        if (currentLife > 100)
        {
            currentLife = 100;
        }
        else if (currentLife < 0)
        {
            currentLife = 0;
        }

        return currentLife;
    }
}
