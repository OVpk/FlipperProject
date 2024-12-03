using UnityEngine;

public class BallLauncherMenu : MonoBehaviour
{
    private Vector3 originScale = new Vector3(0f, 0f, 0f);
    private Vector3 finalScale = new Vector3(1f, 1f, 1f);
    public Vector3 minimumScale = new Vector3(0.9f, 0.9f, 0.9f);

    public float speed = 2f;
    
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject thisCanva;
    
    private bool ballOnField = false;
    
    private void Start()
    {
        transform.localScale = originScale;
    }
    
    private void Update()
    {
        if (Input.GetAxis("DPadVertical") < 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, finalScale, speed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originScale, speed * Time.deltaTime);
        }

        if (transform.localScale.x > minimumScale.x && ballOnField == false)
        {
            ballOnField = true;
            
            Instantiate(ballPrefab, spawnPoint.transform.position, Quaternion.identity);
            
            transform.localScale = originScale;
            ballOnField = false;
            thisCanva.SetActive(false);
        }
    }
}