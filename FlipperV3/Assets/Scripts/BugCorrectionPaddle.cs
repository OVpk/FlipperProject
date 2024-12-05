using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCorrectionPaddle : MonoBehaviour
{
    public Vector3 addedPosition = new Vector3(0f, 0.8f, 0f);
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position += addedPosition;
    }
}
