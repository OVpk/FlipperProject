using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public GameObject reloadBallMenu;
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.parent.gameObject);
        reloadBallMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
