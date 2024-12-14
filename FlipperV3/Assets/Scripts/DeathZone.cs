using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject reloadBallMenu;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.parent.gameObject);
        reloadBallMenu.SetActive(true);
        BallLauncherUi.ballOnField = false;
    }
}
