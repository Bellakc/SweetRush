using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; 
    public GameObject LiqoricePrefab;

    
    public float liqoriceForce = 5f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }

    void Shoot()
    {
       GameObject liqorice = Instantiate(LiqoricePrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb = liqorice.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.right * liqoriceForce, ForceMode2D.Impulse);

        
    }

    
}
