using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManipulationEvent : MonoBehaviour
{
    public TutorialTVmanager tutorialTVmanager;
    public void StopTime()
    {
        Time.timeScale = 0;
        tutorialTVmanager.tutorialIsHere = true;
    }
}
