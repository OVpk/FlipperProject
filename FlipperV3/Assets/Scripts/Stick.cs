using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Animation anim;
    private string animName;
    public float strength;
    private Vector3 angle;

    public enum KeyPossibility
    {
        L2,
        R2
    }
    
    public KeyPossibility choiceKey;
    private string inputAxisName;

    private void Start()
    {
        switch (choiceKey)
        {
            case KeyPossibility.L2 : 
                angle = new Vector3(1,1,0);
                inputAxisName = "L2";
                animName = "StickLeft";
                break;
            case KeyPossibility.R2 : 
                angle = new Vector3(-1,1,0);
                inputAxisName = "R2";
                animName = "StickRight";
                break;
        }
    }
    
    private void Update()
    {
        float axisValue = 0f;
        axisValue = Input.GetAxis(inputAxisName);
        if (axisValue > 0.1f)
        {
            anim.Play(animName);
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        other.GetComponent<Rigidbody>().AddForce(angle * strength);
    }
}
