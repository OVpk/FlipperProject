using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialTVmanager : MonoBehaviour
{

    public GameObject tutorialUIcanva;

    public Animation allTVanim;

    public Animator GIFanimator;

    public TMP_Text textZone;
    
    public enum TutorialState
    {
        Step0,
        Step1,
        Step2
    }
    
    public TutorialState currentStep = TutorialState.Step0;
    
    Dictionary<TutorialState, Dictionary<string, string>> stepValues = new Dictionary<TutorialState, Dictionary<string, string>>
    {
        { TutorialState.Step1, new Dictionary<string, string>
            {
                { "anim", "DifferentMovesGIFanimation" },
                { "text", "Selon la partie du pad touchée par la bille, jaugez l'angle de tir (+ à l'extérieur = revert, + à l'intérieur = direct)" }
            }
        },
        { TutorialState.Step2, new Dictionary<string, string>
            {
                { "anim", "ComboGIFanimation" },
                { "text", "Envoyez la bille, puis frappez la au bon moment avec le batôn pour lui donner une impulsion supplémentaire !" }
            }
        }
    };
    
    // Start is called before the first frame update
    void Start()
    {
        //InitTV();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            CloseTV();
        }
    }

    public void InitTV()
    {
        tutorialUIcanva.SetActive(true);
        allTVanim.Play("TVtutorialCome");
        GIFanimator.Play(stepValues[currentStep]["anim"]);
        textZone.text = stepValues[currentStep]["text"];
    }

    public void CloseTV()
    {
        allTVanim.Play("TVtutorialLeaves");
    }

    public void SwitchStep()
    {
        currentStep = currentStep + 1;
    }
}
