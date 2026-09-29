using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float tapForce = 5f;
    public RuleManager ruleManager;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * tapForce, ForceMode.Impulse);
            ruleManager.ApplyRandomRule();
        }
        if (GameManager.isGameOver) return;

    }
}
