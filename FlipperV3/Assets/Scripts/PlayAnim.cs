using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    [SerializeField] private Animation anim;
    public string animName;
    
    private void OnTriggerEnter(Collider other)
    {
        anim.Play(animName);
    }
}
