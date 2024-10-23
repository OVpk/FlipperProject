using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraFollow : MonoBehaviour
{

    public GameObject objectToFollow;

    public Vector3 distanceWithObjectToFollow;
    // Start is called before the first frame update
    void Start()
    {
        distanceWithObjectToFollow = transform.position - objectToFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.transform.position + distanceWithObjectToFollow;
    }
}
