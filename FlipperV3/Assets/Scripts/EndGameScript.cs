using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private GameObject arrowUi;
    [SerializeField] private GameObject reloadButton;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject cursor;
    [SerializeField] private Animation phoneAnim;
    [SerializeField] private GameObject musicScreen;
    [SerializeField] private GameObject blackScreen;

    public void EndGame()
    {
        musicScreen.SetActive(false);
        arrowUi.SetActive(false);
        reloadButton.SetActive(true);
        menuButton.SetActive(true);
        cursor.SetActive(true);
        blackScreen.SetActive(true);

        phoneAnim.Play("EndGame");
    }
}
