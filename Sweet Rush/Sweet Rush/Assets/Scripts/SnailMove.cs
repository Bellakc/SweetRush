using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailMove : MonoBehaviour
{
    
    public Transform[] waypoints;
    public float speed = 0.15f;

    public GameObject hurtParticles;
    public Animator animator;
 

    private int cur = 0;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        

    }
    void Awake()
    {
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
            
            //animator.SetBool("isHurt", true);
            //speed = 0;
           // StartCoroutine(speedTime());

            //Invoke("KillEnemy", 1.5f);
           
             Instantiate(hurtParticles, col.transform.position, Quaternion.identity);

            //transform.localScale = new Vector3(transform.localScale.y, 0.15f, transform.localScale.z);
            //transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);



            KillEnemy();
            Destroy(col.gameObject);
            
        }

    }


    //IEnumerator speedTime()
    //{
    //    speed = 0;
    //    yield return new WaitForSeconds(1.5f);
    //    revertSpeed();
    //}

    //void revertSpeed()
    //{
    //    Awake();
    //    StartMoving();
    //}



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
