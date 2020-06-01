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



    private Rigidbody2D liqoricePrefab;
    private Transform target;



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
}
    