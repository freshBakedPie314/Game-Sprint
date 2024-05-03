using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float health = 100f;
    NavMeshAgent agent;
    [SerializeField] Transform target;

    public float attackRadius;
    public LayerMask playerMask;

    public PlayerStats data;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRadius, playerMask);
        if(hit != null)
        {
            data.health -= 1;
        }
    }

    public void TakeDamage(float damage)
    {
        health-= damage; 
        if(health <= 0) Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position , attackRadius);
    }
}
