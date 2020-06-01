using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;
    public bool openable;
    public bool locked;


    public int index;
    public Image pink;
    public Animator pinkAnim;


    public GameObject itemNeeded;
    public AudioClip door;
    public AudioClip pickupKey;
    public AudioSource audioSource;
    public GameObject pickUpKeyParticles;


    public Animator anim;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DoInteraction()
    {
        gameObject.SetActive(false);
        audioSource.PlayOneShot(pickupKey, 0.5f);
        Instantiate(pickUpKeyParticles, transform.position, Quaternion.identity);

    }

    public void Open()
    {
        anim.SetBool("open", true);
        audioSource.PlayOneShot(door, 1.0f);
        StartCoroutine(Fading());
    }


    
    public IEnumerator Fading()
    {
        pinkAnim.SetBool("Fade", true);
        yield return new WaitUntil(() => pink.color.a == 2);
        SceneManager.LoadScene(index);

    }

}
