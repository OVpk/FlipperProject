using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public GameObject reloadBallMenu;
    
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.parent.gameObject);
        reloadBallMenu.SetActive(true);
        BallLauncherMenu.ballOnField = false;
    }
}
