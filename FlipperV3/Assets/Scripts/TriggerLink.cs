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
        CheckInstrumentTrigger(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckInstrumentTrigger(other.gameObject);
    }


    private void CheckInstrumentTrigger(GameObject other)
    {
        if (trigger.dictInstrumentState[gameObject.tag])
        {
            
            scoreManager.AddScore(100);

            trigger.valideAction = true;
            trigger.EndInstrument(true);

            other.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }
}
