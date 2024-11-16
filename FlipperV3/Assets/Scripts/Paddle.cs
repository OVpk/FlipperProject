using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float targetPosition = 75;
    public float originPosition = 0;

    public HingeJoint hingeJoint;
    private JointSpring jointSpring;

    private KeyCode key;

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
            case KeyPossibility.L1 : key = KeyCode.JoystickButton4; break;
            case KeyPossibility.R1 : key = KeyCode.JoystickButton5; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            jointSpring.targetPosition = targetPosition;
        }
        else
        {
            jointSpring.targetPosition = originPosition;
        }

        hingeJoint.spring = jointSpring;
    }
}
