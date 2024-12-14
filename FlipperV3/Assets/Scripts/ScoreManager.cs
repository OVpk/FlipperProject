using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Animation phoneAnim;

    private int score;
    
    public void AddScore(int addedNumber)
    {
        score += addedNumber;
        scoreText.text = score.ToString();
        phoneAnim.Play("AddScore");
    }
}
