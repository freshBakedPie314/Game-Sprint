using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public LayerMask enimies;
    public Transform attackPoint;
    public float attackRadius;
    public int damage;
    PlayerStats data;
    public Animator animator;
    public static Action hitSomething;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        data = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().data;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal") , Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        movement = movement * data.playerSpeed;

        rb.velocity = movement;
        if(rb.velocity != Vector2.zero) animator.SetBool("run", true); 
        else animator.SetBool("run", false);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            if (angle > -45f && angle <= 45f)
            {
                animator.SetTrigger("attackRight");
            }
            else if (angle > 45f && angle <= 135f)
            {
                animator.SetTrigger("attackTop");
            }
            else if (angle > 135f && angle <= 180f || angle < -135f)
            {
                animator.SetTrigger("attackLeft");
                Debug.Log("Left");
            }
            else 
            {
                animator.SetTrigger("attackDown");
            }
            
        }
    }

    private void Attack()
    {
        Collider2D[] enimiesHIt = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enimies);
        foreach(Collider2D enenmyHit in enimiesHIt)
        {
            Debug.Log(enenmyHit.name);
            Enemy enemy = enenmyHit.GetComponent<Enemy>();
            Enemy_Ranged enemy_Ranged = enenmyHit.GetComponent<Enemy_Ranged>();
            if (enemy != null)
            {
                enemy.TakeDamage(data.weaponDamage);
                data.weaponDurability -= 1;
                hitSomething?.Invoke();
            }
            if(enemy_Ranged != null)
            {
                enemy_Ranged.TakeDamage(data.weaponDamage);
                data.weaponDurability -= 1;
                hitSomething?.Invoke();
            }

            Bullet b = enenmyHit.GetComponent<Bullet>();
            if(b != null)
            {
                b.gameObject.GetComponent<Rigidbody2D>().velocity *= -2.5f;
                hitSomething?.Invoke();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }


}
