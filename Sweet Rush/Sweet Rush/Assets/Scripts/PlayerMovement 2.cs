using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    public Animator animator;

    public AudioClip pacdotPickup;

    private AudioSource myAudioSource;


    Vector2 movement;
    Vector2 mousePos;


    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

       mousePos= cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg- 90f;
        rb.rotation = angle;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            myAudioSource.PlayOneShot(pacdotPickup, 0.5f);
        }
    }
}
