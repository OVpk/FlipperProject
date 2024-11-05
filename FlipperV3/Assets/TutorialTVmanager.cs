using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public GameObject normalGameSystem;

    public LogoSpawner logoSpawner;
    
    public enum TutorialState
    {
        Step0,
        Step1,
        Step2,
        Step3,
        FinalStep
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
        },
        { TutorialState.Step3, new Dictionary<string, string>
            {
                { "anim", "DetectionBoxGIFanimation" },
                { "text", "Frappez l'instrument correspondant tant qu'il est dans la zone de détection, sinon vous perdez de la vie" },
                {"objectiveText", "Frappez le        pour continuer\n(Seulement quand il est dans la zone de détection)"}
            }
        },
        { TutorialState.FinalStep, new Dictionary<string, string>
        {
            { "anim", "FinishGIFanimation" },
            { "text", "Félicitation !\nVous avez terminé ce tutoriel, profitez à présent du reste du jeu" }
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
            switch (currentStep)
            {
                case TutorialState.Step3 : normalGameSystem.SetActive(true); break;
                case TutorialState.FinalStep : SceneManager.LoadScene(SceneManager.GetActiveScene().name); break;
            }
        }

        if (currentStep == TutorialState.Step3 && logoSpawner.listeEmpty == true)
        {
            currentStep = TutorialState.FinalStep;
            InitTV();
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
            case TutorialState.Step3 : objectiveImage.sprite = drumLogo; break;
        }
        
    }
}
