using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    public int Health
    {
        set
        {
            health = value;

            if (value > 0)
            {
                // Hit animation
            }

            if (health <= 0)
            {
                health = 0;
                Targetable = false;
                if (!isPlayer)
                {
                    RemoveEnemy();
                }
                else
                {
                    PlayerDeath();
                }
            }

            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        get
        {
            return health;
        }
    }

    public bool Targetable
    {
        get { return targetable; }
        set
        {
            targetable = value;
        }
    }

    public int maxHealth = 10;
    public int health = 10;
    public bool isPlayer = false;

    bool targetable = true;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Get animator
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnHit(int damage)
    {
        Health -= damage;
    }

    public void Defeated()
    {
        // Defeat animation
    }

    public virtual void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public virtual void PlayerDeath()
    {
        Targetable = false;
    }
}
