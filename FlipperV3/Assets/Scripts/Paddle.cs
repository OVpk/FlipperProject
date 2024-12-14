using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float targetPosition = 75;
    private float originPosition = 0;
    private float paddleUpDuration = 0.1f;

    [SerializeField] private HingeJoint hingeJoint;
    private JointSpring jointSpring;
    
    public enum KeyPossibility
    {
        L1,
        R1
    }

    public KeyPossibility choiceKey;
    private KeyCode key;
    
    private bool isKeyPressed;
    private float timer;

    private void Start()
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

    private void Update()
    {
        if (Input.GetKeyDown(key) && !isKeyPressed)
        {
            isKeyPressed = true;
            jointSpring.targetPosition = targetPosition;
            timer = paddleUpDuration;
        }
        
        if (isKeyPressed)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                jointSpring.targetPosition = originPosition;
                isKeyPressed = false;
            }
        }

        hingeJoint.spring = jointSpring;
    }
}