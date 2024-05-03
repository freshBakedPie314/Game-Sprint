using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform player;
    public float projectileSpeed = 5f;
    public float shootingInterval = 2f;

    private void Start()
    {
        StartCoroutine(ShootAtPlayer());
    }

    IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingInterval);
            Shoot();
        }
    }

    void Shoot()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        }
    }
}
