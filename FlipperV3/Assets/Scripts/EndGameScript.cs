using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{

    public GameObject arrowUi;

    public GameObject reloadButton;
    public GameObject menuButton;

    public GameObject cursor;

    public Animation phoneAnim;

    public GameObject musicScreen;

    public GameObject blackScreen;

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
