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
    public GameObject attackPoint;
    public float radius;
    public LayerMask Enemies;
    public int damage;
    private PlayerClass player;
    private Animator animator;
    private bool facingRight;
    private bool attacked = false;
    [SerializeField] private Rigidbody2D pb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    //this is the dash
    public float dashSpeed = 15f;
    public float dashTime = 0.2f;
    private bool isDashing = false;
    private float dashTimer;
    private float dashDirection;

    void Start()
    {
        pb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = new PlayerClass(Health, Speed);
    }

    void Update()
    {

        player.takeDamage(0.01f);
        if (!player.isDead())
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            if (movement.x != 0)
            {
                animator.SetBool("IsWalking", true);
                if (movement.x > 0 && facingRight)
                {
                    Flip();
                }
                else if (movement.x < 0 && !facingRight) 
                {
                    Flip();
                }
            }
            else
            {
                animator.SetBool("IsWalking", false);
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
                player.takeDamage(5);
                Debug.Log("Dashed");
            }

            if (Input.GetMouseButtonDown(0) && !attacked)
            {
                animator.SetBool("IsAttacking", true);
                attacked = true;
            }
        }
        


    }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, Enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Hit!");
            enemyGameObject.GetComponent<EnemyScript>().meleeEnemy.takeDamage(damage);
            if (player.getHealth() < player.getMaxHealth())
            {
                player.Heal(damage);
            }
        }
    }

    public void endAttack()
    {
        animator.SetBool("IsAttacking", false);
        attacked = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void FixedUpdate()
    {
        if (player.isDead())
        {
            pb.linearVelocity = Vector2.zero;
            return;
        }
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

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
