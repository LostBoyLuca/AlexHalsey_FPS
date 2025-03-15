using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f; // Bullet damage amount

    void OnTriggerEnter(Collider other)
    {
        // Check if the object hit has EnemyHealth component
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Apply damage
            Destroy(gameObject); // Destroy the bullet
        }
    }
}

