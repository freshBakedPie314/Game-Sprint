using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerStats data;
    float buffer = .5f;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().data;
    }

    // Update is called once per frame
    void Update()
    {
        if(buffer > 0)
        buffer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            data.health -= 1;
            Destroy(gameObject);
        }

        Enemy enemy = collision.GetComponent<Enemy>();
        Enemy_Ranged enemy_Ranged = collision.GetComponent<Enemy_Ranged>();
        if (enemy != null)
        {
            enemy.TakeDamage(data.health);
            Destroy(gameObject);
        }
        if (enemy_Ranged != null)
        {
            if(buffer <= 0)
            {
                enemy_Ranged.TakeDamage(data.health);
                Destroy(gameObject);
            }
            
        }  
    }
}
