using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Exit : MonoBehaviour
{
	public int index;

	public bool questIsComplete = false;
	public int amountOfCandy;
    public Image pink;
    public Animator anim;
	public int requiredCandy;
	public GameController LoadLevel;
    public GameObject key;


    public int levelToLoad;

    public void Start()
    {
        key.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (amountOfCandy == requiredCandy)
        {
            questIsComplete = true;
            key.SetActive(true);
         
        }
         if(other.CompareTag("Player") && questIsComplete)
        {
            StartCoroutine(Fading());
            
        }
        

    }
  
        IEnumerator Fading()
        {
            anim.SetBool("Fade", true);
            yield return new WaitUntil(() => pink.color.a == 1);
            SceneManager.LoadScene(index);

        }





}