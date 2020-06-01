using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailMove : MonoBehaviour
{
    
    public Transform[] waypoints;
    public float speed = 0.15f;
    public GameObject hurtParticles;


    private int cur = 0;
    private Rigidbody2D rb;

    void Awake()
    {
        // Get Ghost Rigidbody
        rb = GetComponent<Rigidbody2D>();

    }

    public void StartMoving()
    {
        transform.position = waypoints[cur].transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else cur = (cur + 1) % waypoints.Length;

        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Lakrits"))
        {

             Instantiate(hurtParticles, col.transform.position, Quaternion.identity);
           
            KillEnemy();
            Destroy(col.gameObject);
            
        }

    }

 

public void KillEnemy()
    {
        EnemyRespawn respawnRef = FindObjectOfType<EnemyRespawn>();
        respawnRef.SpawnEnemy();
        
        Destroy(gameObject);
    }

 
}

//private void DisableObject()
//{
//    Destroy(gameObject);
//}
