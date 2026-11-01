using UnityEngine;

public class GravityButton2 : MonoBehaviour
{
    public RoomRuleManager2 ruleManager;
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Physical"))
        {
            ruleManager.CycleGravity();

            if (animator != null)
            {
                animator.SetTrigger("Press");
            }
        }
    }
}
