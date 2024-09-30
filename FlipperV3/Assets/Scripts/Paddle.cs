using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float targetPosition = 75;
    public float originPosition = 0;

    public HingeJoint hingeJoint;
    private JointSpring jointSpring;

    public KeyCode key;
    
    // Start is called before the first frame update
    void Start()
    {
        jointSpring = hingeJoint.spring;
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
