using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    float score;

    void Update()
    {
        if (GameManager.isGameOver) return;
        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }
}
