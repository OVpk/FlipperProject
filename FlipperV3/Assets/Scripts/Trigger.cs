using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Trigger : MonoBehaviour
{
    
    public Dictionary<string, bool> dictInstrumentState = new Dictionary<string, bool>
    {
        {"Drum", false},
        {"Cymbal", false},
        {"Piano1", false},
        {"Piano2", false},
        {"Piano3", false},
        {"Piano4", false}
    };

    public OutlinerIndication outlinerIndication;
    
    private void StartInstrument()
    {
        dictInstrumentState[currentInstrument] = true;
        
        switch (currentInstrument)
        {
            case "Drum" : outlinerIndication.StartScintillement(outlinerIndication.drumOutliners); break;
            case "Cymbal" : outlinerIndication.StartScintillement(outlinerIndication.cymbalOutliners); break;
            case "Piano1" : outlinerIndication.StartScintillement(outlinerIndication.piano1Outliners); break;
            case "Piano2" : outlinerIndication.StartScintillement(outlinerIndication.piano2Outliners); break;
            case "Piano3" : outlinerIndication.StartScintillement(outlinerIndication.piano3Outliners); break;
            case "Piano4" : outlinerIndication.StartScintillement(outlinerIndication.piano4Outliners); break;
        }
    }

    public AudioSource endActionSong;
    public AudioClip confirmation;
    public AudioClip fail;
    public void EndInstrument(bool byPlayer)
    {
        dictInstrumentState[currentInstrument] = false;
        
        switch (currentInstrument)
        {
            case "Drum" : outlinerIndication.StopScintillement(outlinerIndication.drumOutliners); break;
            case "Cymbal" : outlinerIndication.StopScintillement(outlinerIndication.cymbalOutliners); break;
            case "Piano1" : outlinerIndication.StopScintillement(outlinerIndication.piano1Outliners); break;
            case "Piano2" : outlinerIndication.StopScintillement(outlinerIndication.piano2Outliners); break;
            case "Piano3" : outlinerIndication.StopScintillement(outlinerIndication.piano3Outliners); break;
            case "Piano4" : outlinerIndication.StopScintillement(outlinerIndication.piano4Outliners); break;
        }

        if (byPlayer)
        {
            endActionSong.clip = confirmation;
        }
        else
        {
            endActionSong.clip = fail;
        }
        endActionSong.Play();
    }
    
    
    public bool hasStarted;

    public float timeToAct = 6f;

    public float delayBetweenActions = 2f;

    public bool listeEmpty = false;

    public string currentInstrument;



    void Update()
    {
        if (!hasStarted && Input.anyKeyDown)
        {
            hasStarted = true;
            globalMusic.Play();
            StartCoroutine(LogoSpawn());
        }
        
    }

    public enum InstrumentType
    {
        Drum,
        Cymbal,
        Piano1,
        Piano2,
        Piano3,
        Piano4
    }

    public InstrumentType[] listeInstrument;

    public bool valideAction = false;

    public EndGameScript endGameScript;

    public TMP_Text globalTimer;

    public AudioSource globalMusic;


    private void Start()
    {
        globalTimer.text = listeInstrument.Length.ToString();
    }

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
                case InstrumentType.Piano1 :
                    currentInstrument = "Piano1"; break;
                case InstrumentType.Piano2 :
                    currentInstrument = "Piano2"; break;
                case InstrumentType.Piano3 :
                    currentInstrument = "Piano3"; break;
                case InstrumentType.Piano4 :
                    currentInstrument = "Piano4"; break;
            }
            StartInstrument();
            yield return new WaitForSeconds(timeToAct);
            if (valideAction)
            {
                valideAction = !valideAction;
            }
            else
            {
                EndInstrument(false);
            }
            globalTimer.text = (listeInstrument.Length - (i+1) ).ToString();
            yield return new WaitForSeconds(delayBetweenActions);
        }

        listeEmpty = true;

        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            endGameScript.EndGame();
        }
    }
    
    
}
