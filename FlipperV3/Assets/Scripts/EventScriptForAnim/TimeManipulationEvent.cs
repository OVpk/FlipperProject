using UnityEngine;

public class TimeManipulationEvent : MonoBehaviour
{
    [SerializeField] private TutorialTvManager tutorialTVmanager;
    
    public void StopTime()
    {
        Time.timeScale = 0;
        tutorialTVmanager.tutorialIsHere = true;
    }
}
