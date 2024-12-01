using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public int score;

    public Animation phoneAnim;
    public void AddScore(int addedNumber)
    {
        score += addedNumber;
        scoreText.text = score.ToString();
        phoneAnim.Play("AddScore");
    }
}
