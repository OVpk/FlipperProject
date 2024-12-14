using UnityEngine;

public class TutorialTriggerSwitch : MonoBehaviour
{
    [SerializeField] private TutorialTvManager tutorialManager;

    public TutorialTvManager.TutorialState triggerTutorialStateName;
    private bool alreadyActived = false;

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
