using UnityEngine;
using TMPro;

public enum GravityMode2 { Normal, Low }

public class RoomRuleManager2 : MonoBehaviour
{
    public GravityMode2 currentMode = GravityMode2.Normal;
    public bool isInverted = false; // всегда false на этом уровне, нужно для PlayerController2D2
    public Transform groundCheck;
    public TMP_Text modeText;

    public void CycleGravity()
    {
        currentMode = (GravityMode2)(((int)currentMode + 1) % 2);

        float gravityScale = (currentMode == GravityMode2.Low) ? 0.3f : 1f;

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

        if (modeText != null)
        {
            modeText.text = (currentMode == GravityMode2.Low) ? "Лёгкая гравитация 🪶" : "Обычная гравитация";
        }
    }
}