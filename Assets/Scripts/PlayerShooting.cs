using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform FirePoint;
    public float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to shoot
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = FirePoint.forward * bulletSpeed;
        Destroy(bullet, 3f); // Destroy after 3 sec
    }
}

