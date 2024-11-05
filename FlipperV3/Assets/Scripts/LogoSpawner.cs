using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    
    public bool hasStarted;

    public GameObject logoDrum;
    
    public GameObject logoCymbal;

    public float timeBetweenSpawns = 8f;

    public bool listeEmpty = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                    Instantiate(logoDrum, spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform); break;
                case InstrumentType.Cymbal :
                    Instantiate(logoCymbal, spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform); break;
                
            }
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        listeEmpty = true;
    }
    
}
