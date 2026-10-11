using UnityEngine;

public class GravityButton : MonoBehaviour
{
    public RoomRuleManager ruleManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Триггер сработал, объект: " + other.name + ", тег: " + other.tag);
        if (other.CompareTag("Physical"))
        {
            Debug.Log("Тег совпал, меняем гравитацию");
            ruleManager.ToggleGravity();
        }
    }
}