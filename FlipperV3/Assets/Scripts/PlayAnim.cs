using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public GameObject cymbalModel;
    public void Play()
    {
        cymbalModel.GetComponent<Animation>().Play("moving");
    }
}
