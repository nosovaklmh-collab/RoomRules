using UnityEngine;

public class RoomRuleManager : MonoBehaviour
{
    public bool isInverted = false;
    public Transform playerVisual;

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
            }
        }

        if (playerVisual != null)
        {
            Vector3 rot = playerVisual.localEulerAngles;
            rot.z = isInverted ? 180f : 0f;
            playerVisual.localEulerAngles = rot;
            foreach (GameObject obj in physicalObjects)
{
    Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
        rb.gravityScale = gravityScale;
        rb.linearVelocity = Vector2.zero;
    }
}

        }
    }
    
}
