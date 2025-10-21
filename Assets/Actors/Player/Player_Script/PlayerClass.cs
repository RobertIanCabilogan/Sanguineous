using System;

public class PlayerClass
{
    private float health;
    private float maxHealth;
    private float speed;

    public PlayerClass(float health, float speed)
    {
        maxHealth = health;
        this.health = health;
        this.speed = speed;
    }

    public PlayerClass(float speed)
    {
        this.speed = speed;
        maxHealth = 100;
        health = maxHealth;
    }
    public float getHealth()
    {
        return health;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setHealth(float health)
    {
        this.health = health;
    }

    public void setSpeed(int speed)
    {
        this.speed = speed;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    public void Heal(float value)
    {
        health += value;
    }

    public Boolean isDead()
    {
        return health <= 0;
    }
}
