using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour{

    public AudioClip wallTouch;
    public GameObject explosionParticles;

    private AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Lakrits")
        {
           
            Destroy(col.gameObject);
            Instantiate(explosionParticles, col.transform.position, Quaternion.identity);
            myAudioSource.PlayOneShot(wallTouch, 0.5f);
        }
    }
}
