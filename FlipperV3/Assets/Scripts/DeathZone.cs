using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public LifeDisplay lifeDisplay;

    public GameObject ballPrefab;
    
    Vector3 positionSpawn = new Vector3(4.524f, -1.31f, -0.256f);

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        lifeDisplay.life = lifeDisplay.EditLife(lifeDisplay.life, -50f);
        if (lifeDisplay.life > 0)
        {
            Instantiate(ballPrefab, positionSpawn, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
