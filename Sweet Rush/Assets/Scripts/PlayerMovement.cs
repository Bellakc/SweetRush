using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
//using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 2f;
    public Animator animator;
    public AudioClip pacdotPickup;
    public Text ammoText;
    public GameObject projectile;


    Vector2 movement;

    public Rigidbody2D rb;  
    private string movementDirection;
    
   
    private AudioSource myAudioSource;
    private int ammo = 15;
   


    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 12f;
        animator = GetComponent<Animator>();
        

        movementDirection = "right";

    }

  

    void Update()
    {
     
        if (movementDirection == "right" || Input.GetKeyDown(KeyCode.RightArrow)) { 

            rb.velocity = transform.right * moveSpeed;
            animator.SetFloat("Horizontal", 1f);
            animator.SetFloat("Vertical", 0f);
            movement = new Vector2(1, 0);

        }

       else if (movementDirection == "left" || Input.GetKeyDown(KeyCode.LeftArrow))
        
        {
            rb.velocity = -transform.right * moveSpeed;
            animator.SetFloat("Horizontal", -1f);
            animator.SetFloat("Vertical", 0f);

            movement = new Vector2(-1, 0);

        } else if (movementDirection == "up" || Input.GetKeyDown(KeyCode.UpArrow))
        
        {

            rb.velocity = transform.up * moveSpeed;
            animator.SetFloat("Vertical", 1f);
            animator.SetFloat("Horizontal", 0f);

            movement = new Vector2(0, 1);
        }
        else if (movementDirection == "down" || Input.GetKeyDown(KeyCode.DownArrow)) 
        
        {
  
            rb.velocity = -transform.up * moveSpeed;
            animator.SetFloat("Vertical", -1f);
            animator.SetFloat("Horizontal", 0);

            movement = new Vector2(0, -1);
            
        }


      
        animator.SetFloat("Speed", rb.velocity.magnitude);

        movementDirection = null;

        ammoText.text = ammo.ToString();

    }

    public void Fire ()
    {
        if (ammo > 0)
        {
            Vector2 temp = new Vector2(transform.position.x, transform.position.y);
            GameObject shot = Instantiate(projectile, temp + movement, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity = movement * 20;
            ammo -= 1;
        }
        else
        {

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            myAudioSource.pitch = Random.Range(0.5f, 1.5f);
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

    
   
}
