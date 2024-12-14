using UnityEngine;

public class PlayAnimUniversal : MonoBehaviour
{
    [SerializeField] private Animation anim;
    public string animName;
    
    public void PlayThisAnim()
    {
        anim.Play(animName);
    }
}
