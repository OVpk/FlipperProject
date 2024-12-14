using UnityEngine;

public class PianoKeyTrigger : MonoBehaviour
{
    private Vector3 originPosition;
    private void Start()
    {
        originPosition = transform.parent.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.parent.transform.position += new Vector3(0, 0, 0.1f);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent.transform.position = originPosition;
    }
}
