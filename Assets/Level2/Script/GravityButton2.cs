using UnityEngine;

public class GravityButton2 : MonoBehaviour
{
    public RoomRuleManager2 ruleManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Physical"))
        {
            ruleManager.CycleGravity();
        }
    }
}