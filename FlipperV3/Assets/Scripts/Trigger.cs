using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    
    public Dictionary<string, bool> dictInstrumentState = new Dictionary<string, bool>
    {
        {"Drum", false},
        {"Cymbal", false}
    };

    public OutlinerIndication outlinerIndication;
    
    private void StartInstrument()
    {
        dictInstrumentState[currentInstrument] = true;
        
        switch (currentInstrument)
        {
            case "Drum" : outlinerIndication.StartScintillement(outlinerIndication.drumOutliners); break;
            case "Cymbal" : outlinerIndication.StartScintillement(outlinerIndication.cymbalOutliners); break;
        }
    }



    public void EndInstrument()
    {
        dictInstrumentState[currentInstrument] = false;
        
        switch (currentInstrument)
        {
            case "Drum" : outlinerIndication.StopScintillement(outlinerIndication.drumOutliners); break;
            case "Cymbal" : outlinerIndication.StopScintillement(outlinerIndication.cymbalOutliners); break;
        }
    }
    
    
    public bool hasStarted;

    public float timeBetweenSpawns = 8f;

    public bool listeEmpty = false;

    public string currentInstrument;
    
    void Update()
    {
        if (!hasStarted && Input.anyKeyDown)
        {
            hasStarted = true;
            StartCoroutine(LogoSpawn());
        }
        
    }

    public enum InstrumentType
    {
        Drum,
        Cymbal
    }
    
    public InstrumentType[] listeInstrument;
    
    IEnumerator LogoSpawn()
    {
        for (int i = 0; i < listeInstrument.Length; i++)
        {
            switch (listeInstrument[i])
            {
                case InstrumentType.Drum :
                    currentInstrument = "Drum"; break;
                case InstrumentType.Cymbal :
                    currentInstrument = "Cymbal"; break;
            }
            StartInstrument();
            yield return new WaitForSeconds(timeBetweenSpawns);
            EndInstrument();
            
        }

        listeEmpty = true;
    }

    
}
