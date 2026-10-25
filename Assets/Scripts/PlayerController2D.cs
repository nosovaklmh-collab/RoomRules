using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public Animator animator;
    public RoomRuleManager ruleManager;
    public Transform visualRoot;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float facingDirection = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))

        {
            if (Mathf.Abs(move) > 0.01f) Debug.Log("Move input detected: " + move);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        animator.SetBool("IsJumping", !isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(move));

        
        if (move > 0) facingDirection = 1f;
        else if (move < 0) facingDirection = -1f;

        bool inverted = (ruleManager != null && ruleManager.isInverted);

        Vector3 scale = visualRoot.localScale;
        scale.x = -facingDirection * Mathf.Abs(scale.x);
        Vector3 visualPos = visualRoot.localPosition;
        visualPos.y = inverted ? 0.3f : 0f;  // подберите число под вашу модель
        visualRoot.localPosition = visualPos;
        scale.y = inverted ? -Mathf.Abs(scale.y) : Mathf.Abs(scale.y);
        visualRoot.localScale = scale;
       
    }
}