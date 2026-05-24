using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SOInput soInput;
    [SerializeField] private SOSave soSave;
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float deceleration = 80f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;

    private Rigidbody2D rb;
    private bool shouldJump;

    private bool IsGrounded => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(soSave.currentCheckPoint != Vector3.zero)
            transform.position =  soSave.currentCheckPoint;
    }

    private void Update()
    {
        if (Input.GetKeyDown(soInput.JumpKeyCode) && IsGrounded)
            shouldJump = true;
    }

    private void FixedUpdate()
    {
        float direction = (Input.GetKey(soInput.RightKeyCode) ? 1f : 0f)
                        - (Input.GetKey(soInput.LeftKeyCode) ? 1f : 0f);

        float test = direction != 0f ? acceleration : deceleration;
        float newVelocityX = Mathf.MoveTowards(rb.linearVelocity.x, direction * maxSpeed, test * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector2(newVelocityX, rb.linearVelocity.y);

        if (!shouldJump) return;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        shouldJump = false;
    }
}