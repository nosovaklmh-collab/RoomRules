using UnityEngine;

public class RoomRuleManager : MonoBehaviour
{
    public bool isInverted = false;
    public Transform playerVisual;
    public Transform groundCheck;


 public void ToggleGravity()
{
    isInverted = !isInverted;

    float gravityScale = isInverted ? -1f : 1f;

    GameObject[] physicalObjects = GameObject.FindGameObjectsWithTag("Physical");
    foreach (GameObject obj in physicalObjects)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = gravityScale;
            rb.linearVelocity = Vector2.zero;
        }
    }

    if (groundCheck != null)
    {
        Vector3 pos = groundCheck.localPosition;
        pos.y = isInverted ? Mathf.Abs(pos.y) : -Mathf.Abs(pos.y);
        groundCheck.localPosition = pos;
    }
}
}