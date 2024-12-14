using System;
using UnityEngine;
using Random = System.Random;

public class InstrumentListGenerator : MonoBehaviour
{
    [SerializeField] public GameManagerScript gameManager;
    public int listLength;

    private void Awake()
    {
        GenerateInstruments();
    }

    private void GenerateInstruments()
    {
        gameManager.listeInstrument = new GameManagerScript.InstrumentType[listLength];
        Random random = new Random();

        for (int i = 0; i < gameManager.listeInstrument.Length; i++)
        {
            GameManagerScript.InstrumentType instrumentChoice = 0;
            if (i == 0)
            {
                instrumentChoice = (GameManagerScript.InstrumentType)random.Next(Enum.GetValues(typeof(GameManagerScript.InstrumentType)).Length);
            }
            
            else
            {
                GameManagerScript.InstrumentType precedent = gameManager.listeInstrument[i - 1];

                if (precedent == GameManagerScript.InstrumentType.Drum)
                {
                    
                    switch (random.Next(2))
                    {
                        case 0 : instrumentChoice = GameManagerScript.InstrumentType.Cymbal; break;
                        case 1 : instrumentChoice = (GameManagerScript.InstrumentType)random.Next(Enum.GetValues(typeof(GameManagerScript.InstrumentType)).Length); break;
                    }
                    
                }
                else if (precedent == GameManagerScript.InstrumentType.Cymbal)
                {
                    instrumentChoice = (GameManagerScript.InstrumentType)random.Next(Enum.GetValues(typeof(GameManagerScript.InstrumentType)).Length);
                    if (instrumentChoice == GameManagerScript.InstrumentType.Cymbal)
                    {
                        instrumentChoice -= 1;
                    }
                }
                else if (precedent == GameManagerScript.InstrumentType.Piano1 ||
                         precedent == GameManagerScript.InstrumentType.Piano2 ||
                         precedent == GameManagerScript.InstrumentType.Piano3 ||
                         precedent == GameManagerScript.InstrumentType.Piano4)
                {
                    instrumentChoice = GameManagerScript.InstrumentType.Drum;
                }
            }
            
            gameManager.listeInstrument[i] = instrumentChoice;
        }
    }
}
