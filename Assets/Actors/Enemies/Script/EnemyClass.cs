using UnityEngine;

public class EnemyClass
{
    private float health;
    private float damage;
    private float maxHealth;
    private bool isRanged;

    public EnemyClass(float health, float damage)
    {
        this.health = health;
        this.damage = damage;
        maxHealth = health;
    }

    public EnemyClass(float health, float damage, bool isRanged) : this(health, damage)
    {
        this.isRanged = isRanged;
        this.health = health;
        this.damage = damage;
        maxHealth = health;
    }

    public float getHealth()
    {
        return health;
    }

    public float getDamage()
    {
        return damage;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    public bool isDead() 
    {
        return health <= 0;
    }
      
}
