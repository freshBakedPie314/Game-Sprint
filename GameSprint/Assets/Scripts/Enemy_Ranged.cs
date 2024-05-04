using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Ranged : MonoBehaviour
{
    public float health = 1f;
    public GameObject projectilePrefab;
    public Transform player;
    public float projectileSpeed = 10f;
    float shootingInterval = .25f;
    public float knockbackInterval = 0.2f;
    public PlayerStats data;
    Transform target;
    public Transform shootPosition;
    private void Start()
    {
        shootingInterval = Random.Range(2f, 3f);
        StartCoroutine(ShootAtPlayer());
        data = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().data;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            GameObject projectile = Instantiate(projectilePrefab, shootPosition.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

            Destroy(projectile, 5f);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
        StartCoroutine(KnockBack());
    }

    IEnumerator KnockBack()
    {
        Debug.Log("Knockback");
        Vector3 direction = transform.position - target.position;
        direction.Normalize();
        GetComponent<Rigidbody2D>().AddForce(direction * data.weaponKnockBack, ForceMode2D.Impulse);
        yield return new WaitForSeconds(knockbackInterval);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
