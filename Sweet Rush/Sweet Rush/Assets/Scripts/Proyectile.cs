using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Proyectile : MonoBehaviour
{

    public float speed = 30;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
       // rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
