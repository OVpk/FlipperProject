using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float targetPosition = 75;
    public float originPosition = 0;

    private float paddleUpDuration = 0.15f; // Durée pendant laquelle le paddle reste levé.

    public HingeJoint hingeJoint;
    private JointSpring jointSpring;

    private KeyCode key;

    private bool isKeyPressed; // Indique si la touche est en cours d'utilisation.
    private float timer; // Timer pour la durée du paddle levé.

    public enum KeyPossibility
    {
        L1,
        R1
    }

    public KeyPossibility choiceKey;
    
    // Start is called before the first frame update
    void Start()
    {
        jointSpring = hingeJoint.spring;

        switch (choiceKey)
        {
            case KeyPossibility.L1: key = KeyCode.JoystickButton4; break;
            case KeyPossibility.R1: key = KeyCode.JoystickButton5; break;
        }

        isKeyPressed = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Si la touche est pressée et que le paddle n'est pas déjà activé
        if (Input.GetKeyDown(key) && !isKeyPressed)
        {
            isKeyPressed = true;
            jointSpring.targetPosition = targetPosition;
            timer = paddleUpDuration; // Démarrer le timer.
        }

        // Compte à rebours pour ramener le paddle à l'origine après la durée définie
        if (isKeyPressed)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                jointSpring.targetPosition = originPosition;
                isKeyPressed = false; // Réinitialiser pour permettre une nouvelle pression.
            }
        }

        hingeJoint.spring = jointSpring;
    }
}