using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTVmanager : MonoBehaviour
{

    public GameObject tutorialUIcanva;

    public GameObject objectiveCanva;

    public Animation allTVanim;

    public Animator GIFanimator;

    public TMP_Text textZone;

    public TMP_Text objectiveTextZone;

    public Image objectiveImage;

    public Sprite drumLogo;
    
    public Sprite cymbalLogo;
    
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
                { "text", "Selon la partie du pad touchée par la bille, jaugez l'angle de tir (+ à l'extérieur = revert, + à l'intérieur = direct)" },
                {"objectiveText", "Frappez le        pour continuer\nAstuce : Faites un revert avec le pad violet"}
            }
        },
        { TutorialState.Step2, new Dictionary<string, string>
            {
                { "anim", "ComboGIFanimation" },
                { "text", "Envoyez la bille, puis frappez la au bon moment avec le batôn pour lui donner une impulsion supplémentaire !" },
                {"objectiveText", "Frappez le        pour continuer\nAstuce : Frappez la bille avec le bâton de gauche"}
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

    public void ShowObjective()
    {
        objectiveCanva.SetActive(true);
        objectiveTextZone.text = stepValues[currentStep]["objectiveText"];
        switch (currentStep)
        {
            case TutorialState.Step1 : objectiveImage.sprite = drumLogo; break;
            case TutorialState.Step2 : objectiveImage.sprite = cymbalLogo; break;
        }
        
    }
}
