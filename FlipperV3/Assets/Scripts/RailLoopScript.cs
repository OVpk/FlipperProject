using Unity.VisualScripting;
using UnityEngine;

public class RailLoopScript : MonoBehaviour
{
    [SerializeField] private GameObject startAnimPosition;
    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent.position = startAnimPosition.transform.position;
        other.transform.parent.GetChild(1).GameObject().SetActive(true);
        other.GetComponent<Animation>().Play("BallInRail");
    }
}
