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



    private Rigidbody2D rb;
    private bool isGrounded;

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
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    animator.SetBool("IsJumping", !isGrounded);
    animator.SetFloat("Speed", Mathf.Abs(move));

    Vector3 scale = animator.transform.localScale;
scale.y = (ruleManager != null && ruleManager.isInverted) ? -Mathf.Abs(scale.y) : Mathf.Abs(scale.y);
animator.transform.localScale = scale;

if (move > 0)
{
    animator.transform.localEulerAngles = new Vector3(0, 90f, 0);
}
else if (move < 0)
{
    animator.transform.localEulerAngles = new Vector3(0, -90f, 0);
}

}

}