using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string nextSceneName = "Level2";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Physical"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Door triggered by: " + other.name + ", tag: " + other.tag);
            if (other.CompareTag("Physical"))
            {
                Debug.Log("Loading next scene: " + nextSceneName);
                SceneManager.LoadScene(nextSceneName);
            }
        }

    }
}