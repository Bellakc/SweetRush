using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour{

    public AudioClip wallTouch;

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

            myAudioSource.PlayOneShot(wallTouch, 0.5f);
        }
    }
}
