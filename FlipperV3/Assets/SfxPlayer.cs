using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    
    public void PlaySfx(AudioSource audioSource)
    {
        audioSource.Play();
    }
}
