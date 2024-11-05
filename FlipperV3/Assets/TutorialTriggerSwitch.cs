using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggerSwitch : MonoBehaviour
{

    public TutorialTVmanager tutorialManager;

    public bool alreadyActived = false;

    public TutorialTVmanager.TutorialState triggerTutorialStateName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyActived && triggerTutorialStateName == tutorialManager.currentStep)
        {
            alreadyActived = true;
            tutorialManager.SwitchStep();
            tutorialManager.InitTV();
            tutorialManager.ShowObjective();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!alreadyActived && triggerTutorialStateName == tutorialManager.currentStep)
        {
            alreadyActived = true;
            tutorialManager.SwitchStep();
            tutorialManager.InitTV();
            tutorialManager.ShowObjective();
        }
    }
}
