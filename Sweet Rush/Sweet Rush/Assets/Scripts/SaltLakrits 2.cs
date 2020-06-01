using UnityEngine;

public class SaltLakrits : MonoBehaviour
{
    public AudioClip hurt;

    private AudioSource audioSource;

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

    //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //Destroy(effect, 3f);
    //Destroy(gameObject);


    //public Transform spawnPoint;
    //public GameObject hitEffect;
    //public GameObject projectile;
    //public int speed = 5;

    //private void OnTriggerEnter2D(Collider2D co)
    //{
    //    if (co.tag == "Enemy")
    //    {
    //        Destroy(gameObject);

    //        co.gameObject.SetActive(false);
    //        StartCoroutine(Respawn(co.gameObject));

    //    }
    //}

    //IEnumerator Respawn(GameObject gObj)
    //{
    //    yield return new WaitForSeconds(4);
    //    gObj.transform.position = spawnPoint.transform.position;
    //    gObj.SetActive(true);
    // GetComponent<GhostMove>().Start();



    //private void Attack()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        GameObject bullet = Instantiate(projectile, projectile.transform.position, Quaternion.identity) as GameObject;
    //        bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * speed);
    //    }
    //}




    


