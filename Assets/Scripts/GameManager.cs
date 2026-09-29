using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public TMP_Text gameOverText;
    public ScoreManager scoreManager;

    void Start() { isGameOver = false; }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        int score = scoreManager.GetScore();
        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("BestScore", best);
        }

        gameOverText.text = "Game Over\nScore: " + score + "\nBest: " + best + "\nTap to restart";
        gameOverText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            Physics.gravity = new Vector3(0, -9.81f, 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
