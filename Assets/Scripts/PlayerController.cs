using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float tapForce = 5f;
    public float maxSpeed = 10f;
    public RuleManager ruleManager;
    public Camera mainCamera;
    public float maxHeightAboveCamera = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.isGameOver) return;

        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * tapForce, ForceMode.Impulse);
            ruleManager.ApplyRandomRule();
        }

        Vector3 v = rb.linearVelocity;
        v.y = Mathf.Clamp(v.y, -maxSpeed, maxSpeed);
        rb.linearVelocity = v;

        // Ќевидимый потолок, следующий за камерой
        float ceiling = mainCamera.transform.position.y + maxHeightAboveCamera;
        if (transform.position.y > ceiling)
        {
            transform.position = new Vector3(transform.position.x, ceiling, transform.position.z);
            v = rb.linearVelocity;
            v.y = Mathf.Min(v.y, 0);
            rb.linearVelocity = v;
        }
    }
}