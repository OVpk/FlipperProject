using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialTvManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialUIcanva;
    [SerializeField] private GameObject objectiveCanva;
    [SerializeField] private Animation allTVanim;
    [SerializeField] private Animator GIFanimator;
    [SerializeField] private TMP_Text textZone;
    [SerializeField] private TMP_Text objectiveTextZone;
    [SerializeField] private Image objectiveImage;
    [SerializeField] private Sprite drumLogo;
    [SerializeField] private Sprite cymbalLogo;
    [SerializeField] private GameObject normalGameSystem;
    [SerializeField] private GameManagerScript gameManager;
    Dictionary<TutorialState, Dictionary<string, string>> stepValues = new Dictionary<TutorialState, Dictionary<string, string>>
    {
        { TutorialState.Step1, new Dictionary<string, string>
            {
                { "anim", "DifferentMovesGIFanimation" },
                { "text", "Selon la partie du pad qui frappe la bille, l'angle de tir est différent" },
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
                { "text", "Frappez les instruments quand ils scintillent pour gagner des points " },
                {"objectiveText", ""}
            }
        },
        { TutorialState.FinalStep, new Dictionary<string, string>
            {
                { "anim", "FinishGIFanimation" },
                { "text", "Félicitation !\nVous avez terminé ce tutoriel, profitez à présent du reste du jeu" },
                {"objectiveText", ""}
            }
        }
    };
    
    
    public enum TutorialState
    {
        Step0,
        Step1,
        Step2,
        Step3,
        FinalStep
    }
    [HideInInspector] public TutorialState currentStep = TutorialState.Step0;

    [HideInInspector] public bool tutorialIsHere = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.JoystickButton1) && tutorialIsHere)
        {
            Time.timeScale = 1;
            switch (currentStep)
            {
                case TutorialState.Step3 : normalGameSystem.SetActive(true); break;
                case TutorialState.FinalStep : SceneManager.LoadScene("Menu"); return;
            }
            ShowObjective();
            CloseTV();
        }

        if (currentStep == TutorialState.Step3 && gameManager.listeEmpty == true)
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

    private void CloseTV()
    {
        tutorialIsHere = false;
        allTVanim.Play("TVtutorialLeaves");
    }

    public void SwitchStep()
    {
        currentStep += 1;
    }

    private void ShowObjective()
    {
        objectiveCanva.SetActive(true);
        objectiveTextZone.text = stepValues[currentStep]["objectiveText"];
        switch (currentStep)
        {
            case TutorialState.Step1 : objectiveImage.sprite = drumLogo; break;
            case TutorialState.Step2 : objectiveImage.sprite = cymbalLogo; break;
            case TutorialState.Step3 : objectiveImage.transform.parent.gameObject.SetActive(false); break;
        }
    }
}
