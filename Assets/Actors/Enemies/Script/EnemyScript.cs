using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Health;
    public float Damage;

    public EnemyClass meleeEnemy;
    void Start()
    {
        meleeEnemy = new EnemyClass(Health, Damage);
    }

    // Update is called once per frame
    void Update()
    {
        if (meleeEnemy.isDead())
        {
            Debug.Log("I'm dead lol");
        }
    }
}
