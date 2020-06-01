using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailMove : MonoBehaviour
{
    
    public Transform[] waypoints;
    public float speed = 0.16f;

    public GameObject hurtParticles;
    public GameObject backParticles;
    public Animator animator;
 

    private int cur = 0;
    private Rigidbody2D rb;

    private bool testBool = true;
    private Vector3 startPos;

    private void Start()
    {
        animator = GetComponent<Animator>();

        speed = 0.16f;

        startPos = transform.position;

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
        else
        {
            cur = (cur + 1) % waypoints.Length;
        }

       
            Vector2 dir = waypoints[cur].position - transform.position;

        if (testBool)
        {
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
        }

        
       

        


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Lakrits"))
        { 

          
            Destroy(col.gameObject);
            StartSpeedTime();



        }

    }

    void StartSpeedTime()
    {
        
        StartCoroutine("speedTime");
    }
   

    IEnumerator speedTime()
    {   
        speed = 0;
        testBool = false;
        animator.SetFloat("DirX", 0);
        animator.SetFloat("DirY", 0);
        //animator.Play("SnailDeath");
        animator.SetTrigger("Die");
        
        yield return new WaitForSeconds(1.0f);
        Instantiate(hurtParticles, transform.position, Quaternion.identity);

        KillEnemy();
        speed = 0.18f;
        testBool = true;

    }


    public void KillEnemy()
    {

       
        transform.position = startPos;
        Instantiate(backParticles, transform.position, Quaternion.identity);
        cur = 0;
    }

 
}
