using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour

{
    public Transform startPosition;
    public float speed = 0.4f;
    public bool right;
    public bool left;
    public bool up;
    public bool down;

    public Sprite pausedSprite;

    private Vector2 dest = Vector2.zero;
    public Rigidbody2D rb;
   

    void Awake()
    {
        // Get Pac-man Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        dest = transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if ((Vector2)transform.position == dest)
        {


            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }


    bool valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
    void UpdateEatingAnimation()
    {
        if (rb.velocity == Vector2.zero)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = pausedSprite;
        }

    }
}