using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public GameObject objetActuel;
    
    public Dictionary<string, bool> dictInstrumentState = new Dictionary<string, bool>
    {
        {"Drum", false},
        {"Cymbal", false}
    };

    public OutlinerIndication outlinerIndication;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < dictInstrumentState.Count; i++)
        {
            string key = dictInstrumentState.ElementAt(i).Key;
            
            if (other.gameObject.tag == key + "LogoTag")
            {
                dictInstrumentState[key] = true;
                switch (key)
                {
                    case "Drum" : outlinerIndication.StartScintillement(outlinerIndication.drumOutliners); break;
                    case "Cymbal" : outlinerIndication.StartScintillement(outlinerIndication.cymbalOutliners); break;
                }
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
                dictInstrumentState[key] = false;
                Destroy(other.gameObject);
                
                switch (key)
                {
                    case "Drum" : outlinerIndication.StopScintillement(outlinerIndication.drumOutliners); break;
                    case "Cymbal" : outlinerIndication.StopScintillement(outlinerIndication.cymbalOutliners); break;
                }
            }
        }
    }

    
}
