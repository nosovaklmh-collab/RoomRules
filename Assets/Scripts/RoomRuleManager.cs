using UnityEngine;

public class RoomRuleManager : MonoBehaviour
{
    public bool isInverted = false;

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
    }
}