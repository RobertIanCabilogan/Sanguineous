using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Vector2 movement;
    private Vector2 currentVelocity = Vector2.zero;
    public float jumpVel = 10f;
    public float Health = 0;
    public float Speed = 0;
    private PlayerClass player;
    [SerializeField] private Rigidbody2D pb;
    [SerializeField] private CapsuleCollider2D playerHitbox;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //this is the dash
    public float dashSpeed = 15f;
    public float dashTime = 0.2f;
    private bool isDashing = false;
    private float dashTimer;
    private float dashDirection;
    //[SerializeField] private Transform cameraTransform;

    void Start()
    {
        pb = GetComponent<Rigidbody2D>();
        player = new PlayerClass(Health, Speed);
    }

    void Update()
    {

        if (!player.isDead())
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }
        

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            pb.linearVelocity = new Vector2(pb.linearVelocity.x, jumpVel);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            dashDirection = movement.x != 0 ? Mathf.Sign(movement.x) : 1f;

            isDashing = true;
            dashTimer = dashTime;
            Debug.Log("Dashed");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void FixedUpdate()
    {

        if (isDashing)
        {
            Vector2 targetVelocity = new Vector2(dashDirection * dashSpeed, pb.linearVelocity.y);
            pb.linearVelocity = Vector2.Lerp(pb.linearVelocity, targetVelocity, 0.8f);
            dashTimer -= Time.fixedDeltaTime;

            if (dashTimer <= 0)
            {
                isDashing = false;
            }
        }
        else
        {
            Vector2 targetVelocity = new Vector2(movement.x * player.getSpeed(), pb.linearVelocity.y);
            pb.linearVelocity = Vector2.Lerp(pb.linearVelocity, targetVelocity, 0.3f);
        }
        

        //cameraTransform.position = Vector3.Lerp(
        //    cameraTransform.position,
        //    new Vector3(pb.position.x + cameraOffset.x, pb.position.y + cameraOffset.y, cameraTransform.position.z),
        //    0.6f
        //);

    }
}
