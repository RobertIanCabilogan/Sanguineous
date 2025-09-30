using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D pb;
    private Vector2 movement;
    private Vector2 currentVelocity = Vector2.zero;
    public float jumpVel;
    public float playerSpeed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 v = pb.linearVelocity;
            v.y = jumpVel;
            pb.linearVelocity = v;
        }
        
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(movement.x, 0f) * playerSpeed;
        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, 0.3f);
        pb.MovePosition(pb.position + currentVelocity * Time.fixedDeltaTime);
    }


}
