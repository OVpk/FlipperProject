using UnityEngine;

public class PutTutoBoxAtRightSize : MonoBehaviour
{
    [SerializeField] private Animation boxAnim;
    
    public void Go()
    {
        boxAnim.Play("ReplierBox");
    }
}
