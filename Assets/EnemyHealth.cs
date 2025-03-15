using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f; // Enemy health

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destroys the enemy
    }
}

