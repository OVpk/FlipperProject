using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggerSwitch : MonoBehaviour
{

    public TutorialTVmanager tutorialManager;

    public bool alreadyActived = false;

    public TutorialTVmanager.TutorialState triggerTutorialStateName;

    private void OnTriggerEnter(Collider other)
    {
        TutorialEvent();
    }

    private void OnCollisionEnter(Collision other)
    {
        TutorialEvent();
    }

    private void TutorialEvent()
    {
        if (!alreadyActived && triggerTutorialStateName == tutorialManager.currentStep)
        {
            alreadyActived = true;
            tutorialManager.SwitchStep();
            tutorialManager.InitTV();
        }
    }
}
