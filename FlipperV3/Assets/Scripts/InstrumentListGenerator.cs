using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class InstrumentListGenerator : MonoBehaviour
{
    
    public int listLength;

    public Trigger trigger;

    private void Awake()
    {
        GenererInstruments();
    }
    
    public void GenererInstruments()
    {
        trigger.listeInstrument = new Trigger.InstrumentType[listLength];
        Random random = new Random();

        for (int i = 0; i < trigger.listeInstrument.Length; i++)
        {
            Trigger.InstrumentType instrumentChoice = 0;
            if (i == 0)
            {
                // Le premier instrument est généré aléatoirement
                instrumentChoice = (Trigger.InstrumentType)random.Next(Enum.GetValues(typeof(Trigger.InstrumentType)).Length);
            }
            else
            {
                Trigger.InstrumentType precedent = trigger.listeInstrument[i - 1];

                if (precedent == Trigger.InstrumentType.Drum)
                {
                    
                    switch (random.Next(2))
                    {
                        case 0 : instrumentChoice = Trigger.InstrumentType.Cymbal; break;
                        case 1 : instrumentChoice = (Trigger.InstrumentType)random.Next(Enum.GetValues(typeof(Trigger.InstrumentType)).Length); break;
                    }
                    
                }
                else if (precedent == Trigger.InstrumentType.Cymbal)
                {
                    // Si le précédent est Cymbal, l'instrument suivant est aléatoire sauf Cymbal
                    instrumentChoice = (Trigger.InstrumentType)random.Next(Enum.GetValues(typeof(Trigger.InstrumentType)).Length);
                    if (instrumentChoice == Trigger.InstrumentType.Cymbal)
                    {
                        instrumentChoice -= 1;
                    }
                }
                else if (precedent == Trigger.InstrumentType.Piano1 ||
                         precedent == Trigger.InstrumentType.Piano2 ||
                         precedent == Trigger.InstrumentType.Piano3 ||
                         precedent == Trigger.InstrumentType.Piano4 ||
                         precedent == Trigger.InstrumentType.Bell)
                {
                    // Si le précédent est un Piano ou Bell, le suivant est toujours Drum
                    instrumentChoice = Trigger.InstrumentType.Drum;
                }
                else
                {
                    // Autres cas, génère un instrument aléatoire
                    instrumentChoice = (Trigger.InstrumentType)random.Next(Enum.GetValues(typeof(Trigger.InstrumentType)).Length);
                }
            }
            trigger.listeInstrument[i] = instrumentChoice;
            
        }
    }
    
}
