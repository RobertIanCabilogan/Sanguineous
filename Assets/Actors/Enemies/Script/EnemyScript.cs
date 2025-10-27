using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Health;
    public float Damage;
    public BoxCollider2D attackZone;
    public EnemyClass meleeEnemy;
    public Animator anim;

    void Start()
    {
        meleeEnemy = new EnemyClass(Health, Damage);
    }

    // Update is called once per frame
    void Update()
    {
        if (meleeEnemy.isDead())
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControls player = collision.gameObject.GetComponent<PlayerControls>();
            if (player != null)
            {
                player.player.takeDamage(Damage);
                Debug.Log("Enemy hit the player!");
            }
        }
    }
}
