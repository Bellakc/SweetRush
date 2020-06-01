using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Animator animator;
    public AudioClip pacdotPickup;

    public GameObject projectile;

    Vector2 movement;

    public Rigidbody2D rb;  
    private string movementDirection;
    
   
    private AudioSource myAudioSource;
    [SerializeField]
    private GameObject[] liqoricePrefab;

    


    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 15f;
        animator = GetComponent<Animator>();
        

        movementDirection = "right";

    }

  

    void Update()
    {
     
        if (movementDirection == "right") { 

            rb.velocity = transform.right * moveSpeed;
            animator.SetFloat("Horizontal", 1f);
            animator.SetFloat("Vertical", 0f);
            movement = new Vector2(1, 0);

        }

       else if (movementDirection == "left")
        
        {
            rb.velocity = -transform.right * moveSpeed;
            animator.SetFloat("Horizontal", -1f);
            animator.SetFloat("Vertical", 0f);

            movement = new Vector2(-1, 0);

        } else if (movementDirection == "up")
        
        {

            rb.velocity = transform.up * moveSpeed;
            animator.SetFloat("Vertical", 1f);
            animator.SetFloat("Horizontal", 0f);

            movement = new Vector2(0, 1);
        }
        else if (movementDirection == "down")
        
        {
  
            rb.velocity = -transform.up * moveSpeed;
            animator.SetFloat("Vertical", -1f);
            animator.SetFloat("Horizontal", 0);

            movement = new Vector2(0, -1);
            
        }

        if(CrossPlatformInputManager.GetButtonDown("Shoot"))
        {
            FireSpell();
        }

      
        animator.SetFloat("Speed", rb.velocity.magnitude);

        movementDirection = null;

    }

    public void Fire ()
    {
        Vector2 temp = new Vector2(transform.position.x, transform.position.y);
        GameObject shot = Instantiate(projectile, temp + movement, Quaternion.identity);
        shot.GetComponent<Rigidbody2D>().velocity = movement * 30;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            myAudioSource.PlayOneShot(pacdotPickup, 0.5f);
        }

       
    }




    public void LeftButton()
    {
        movementDirection = "left";

    }

    public void RightButton ()

    {
        movementDirection = "right";
     
    }

    public void UpButton ()

    {
        movementDirection = "up";
    }

    public void DownButton ()
    {
        movementDirection = "down";
    }

    
    public void FireSpell()
    {
        Instantiate(liqoricePrefab[0], transform.position, Quaternion.identity) ;
    }
}
