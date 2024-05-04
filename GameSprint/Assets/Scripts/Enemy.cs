using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour
{
    public float health = 5f;
    NavMeshAgent agent;
    [SerializeField] Transform target;
    public float attackRadius;
    public LayerMask playerMask;
    public float attackInterval;
    public PlayerStats data;
    public float knockbackInterval = 0.2f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        StartCoroutine(AttackPlayer());

        data = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().data;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    private void Attack()
    {
        Vector3 direction = transform.position - target.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRadius, playerMask);
        if (hit != null)
        {
            data.health -= 1;
            
            animator.SetTrigger("attackRight");
            
        }

        
    }
    public void TakeDamage(float damage)
    {
        health-= damage; 
        if(health <= 0) Destroy(gameObject);
        StartCoroutine(KnockBack());
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position , attackRadius);
    }

    IEnumerator AttackPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);
            Attack();
        }
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
