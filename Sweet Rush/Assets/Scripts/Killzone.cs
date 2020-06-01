using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public AudioClip hurtPlayer;



    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(hurtPlayer, 0.3f);
            GameController.gameControllerInstance.ScreenShake();
        }

    }

}