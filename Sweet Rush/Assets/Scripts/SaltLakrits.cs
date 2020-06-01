using UnityEngine;

public class SaltLakrits : MonoBehaviour
{
    public AudioClip hurt;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))

        {
            Debug.Log("Enemy");
            audioSource.PlayOneShot(hurt, 0.5f);
        }
    }
}

   



    


