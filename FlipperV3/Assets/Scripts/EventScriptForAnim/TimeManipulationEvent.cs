using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManipulationEvent : MonoBehaviour
{
    public void StopTime()
    {
        Time.timeScale = 0;
    }
}
