using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncherMenu : MonoBehaviour
{
    
    public KeyCode key;

    public Vector3 originScale = new Vector3(0f, 0f, 0f);

    public Vector3 finalScale = new Vector3(1f, 1f, 1f);

    public Vector3 minimumScale = new Vector3(0.9f, 0.9f, 0.9f);

    public float speed = 2f;
    
    public GameObject ballPrefab;

    public GameObject spawnPoint;

    public Vector3 positionSpawn;

    public bool ballOnFieldCheck = false;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = originScale;
        positionSpawn = spawnPoint.transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            transform.localScale = Vector3.Lerp(transform.localScale, finalScale, speed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originScale, speed * Time.deltaTime);
        }

        if (transform.localScale.x > minimumScale.x && ballOnFieldCheck == false)
        {
            ballOnFieldCheck = true;
            Instantiate(ballPrefab, positionSpawn, Quaternion.identity);
        }

        if (!Input.GetKey(key) && ballOnFieldCheck == true)
        {
            transform.localScale = originScale;
            ballOnFieldCheck = false;
            transform.parent.gameObject.SetActive(false);
        }
    }
}