using UnityEngine;

public class BallCameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject objectToFollow;

    private Vector3 distanceWithObjectToFollow;

    private void Start()
    {
        distanceWithObjectToFollow = transform.position - objectToFollow.transform.position;
        gameObject.SetActive(false);
    }
    
    private void Update()
    {
        transform.position = objectToFollow.transform.position + distanceWithObjectToFollow;
    }
}
