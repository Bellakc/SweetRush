using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Shooting : MonoBehaviour
{

    

    [SerializeField]
    float liqoriceSpeed = 500;
    public GameObject[] liqorice;
    public static float remainingShots = 14;

    public Transform shotText;


    //public Transform firePoint;
    private Rigidbody2D liqoricePrefab;
    private Transform target;

   // public float liqoriceForce = 5f;


    private void Start()
    {
        liqoricePrefab = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Enemy").transform;
        FindClosestEnemy();
   }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;

        liqoricePrefab.velocity = direction.normalized * liqoriceSpeed;
    }

    //void Update()
    //{
    //    if (CrossPlatformInputManager.GetButtonDown("Shoot"))
    //    {
    //        Fire();
    //    }

    //}

    // void Fire()
    //{
    //     Instantiate(liqorice[0], transform.position, Quaternion.identity);
    //    //var fireLiqorice = Instantiate(LiqoricePrefab, firePoint.position, firePoint.rotation);
    //    //fireLiqorice.AddForce(firePoint.up * liqoriceSpeed);
    //}


}


 // void Update()
 //{
 //    if (Input.GetButtonDown("Fire1"))
 //    {
 //        Shoot();

 //    }
 //}

 //void Shoot()
 //{
 //   GameObject liqorice = Instantiate(LiqoricePrefab, firePoint.position, firePoint.rotation);
 //   Rigidbody2D rb = liqorice.GetComponent<Rigidbody2D>();
 //   rb.AddForce(firePoint.right * liqoriceForce, ForceMode2D.Impulse);


 //}

 
