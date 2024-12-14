using UnityEngine;

public class InstrumentTriggerLink : MonoBehaviour
{
    [SerializeField] private GameManagerScript gameManager;

    [SerializeField] private ScoreManager scoreManager;

    private void OnCollisionEnter(Collision other)
    {
        CheckInstrumentTrigger(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckInstrumentTrigger(other.gameObject);
    }

    private void CheckInstrumentTrigger(GameObject other)
    {
        if (gameManager.dictInstrumentState[gameObject.tag])
        {
            scoreManager.AddScore(100);

            gameManager.valideAction = true;
            gameManager.EndInstrument(true);

            other.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }
}
