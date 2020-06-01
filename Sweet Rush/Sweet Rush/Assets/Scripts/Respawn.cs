using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject go = other.gameObject;

        if (other.transform.name == "Girl")
        {
            Instantiate(go, new Vector2(14, 14), Quaternion.identity);
           // other.transform.position = respawnPoint.transform.position;
            //Physics2D.SyncTransforms();
            //player.transform.position = respawnPoint.transform.position;
        }
    }

}