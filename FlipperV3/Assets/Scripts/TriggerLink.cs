using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerLink : MonoBehaviour
{
    public Trigger trigger;

    public ScoreManager scoreManager;

    private void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < trigger.dictInstrumentState.Count; i++)
        {
            string key = trigger.dictInstrumentState.ElementAt(i).Key;
            
            if (gameObject.tag == key + "LogoTag" && trigger.dictInstrumentState[key])
            {
                scoreManager.AddScore(100);
                trigger.dictInstrumentState[key] = false;
                Destroy(trigger.objetActuel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < trigger.dictInstrumentState.Count; i++)
        {
            string key = trigger.dictInstrumentState.ElementAt(i).Key;
            
            if (gameObject.tag == key + "LogoTag" && trigger.dictInstrumentState[key])
            {
                scoreManager.AddScore(100);
                trigger.dictInstrumentState[key] = false;
                Destroy(trigger.objetActuel);
            }
        }
    }
}
