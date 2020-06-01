using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;
    public bool openable;
    public bool locked;

    public GameObject itemNeeded;
    public AudioClip door;
    public AudioClip pickupKey;
    public AudioSource audioSource;

  
    public Animator anim;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DoInteraction()
    {
        gameObject.SetActive(false);
        audioSource.PlayOneShot(pickupKey, 0.5f);
    }

    public void Open()
    {
        anim.SetBool("open", true);
        audioSource.PlayOneShot(door, 0.5f);
    }
 
}
