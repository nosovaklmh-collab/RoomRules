using UnityEngine;

public class LevelExit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Physical"))
        {
            Debug.Log("Уровень пройден!");
            // здесь позже: переход на следующий уровень или экран победы
        }
    }
}