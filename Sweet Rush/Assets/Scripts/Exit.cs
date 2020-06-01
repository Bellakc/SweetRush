using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Exit : MonoBehaviour
{
	

	public bool questIsComplete = false;
	public int amountOfCandy;
 
	public int requiredCandy;
	public GameController LoadLevel;
    public GameObject key;
    public GameObject button;

    public int levelToLoad;


    public void Start()
    {
        key.SetActive(false);
        button.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (amountOfCandy != requiredCandy)
        {
            questIsComplete = false;
            key.SetActive(false);
        }
        else
        {
            questIsComplete = true;
            key.SetActive(true);
            button.SetActive(true);



        }
        
        

    }
  
      




}