using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, 2f, -10f);

    void Start()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }

    void LateUpdate()
    {
        float targetY = player.position.y + offset.y;
        if (targetY > transform.position.y)
        {
            Vector3 targetPos = new Vector3(transform.position.x, targetY, offset.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
        }
    }
}