using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    
    Vector3 positionSpawn = new Vector3(4.524f, -1.31f, -0.25f);

    private Quaternion rotationSpawn = new Quaternion();
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Instantiate(other, positionSpawn, rotationSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
