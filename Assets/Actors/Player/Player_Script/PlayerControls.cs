using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Vector2 movement;
    private Vector2 currentVelocity = Vector2.zero;
    public float jumpVel = 10f;
    public float playerSpeed = 5f;
    private Vector2 cameraOffset = new Vector2(0, 2);

    [SerializeField] private Rigidbody2D pb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform Camera;

    void Start()
    {
        pb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            pb.linearVelocity = new Vector2(pb.linearVelocity.x, jumpVel);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void FixedUpdate()
    {
        // Horizontal movement
        Vector2 targetVelocity = new Vector2(movement.x * playerSpeed, pb.linearVelocity.y);
        pb.linearVelocity = Vector2.Lerp(pb.linearVelocity, targetVelocity, 0.3f);

        if (Camera != null)
        {
            Camera.position = pb.position;
        }
    }
}
