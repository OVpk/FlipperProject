using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    
    public bool hasStarted;

    public GameObject logoDrum;
    
    public string[] listeInstrument;

    public float timeBetweenSpawns = 8f;
    
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
    
    IEnumerator LogoSpawn()
    {
        for (int i = 0; i < listeInstrument.Length; i++)
        {
            if (listeInstrument[i] == "Drum")
            {
                Instantiate(logoDrum, spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform);
            }

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
    
}
