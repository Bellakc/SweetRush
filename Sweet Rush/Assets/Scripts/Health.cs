using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Health : MonoBehaviour
{


    public int health= 3;
    public float currentHealth;
    public int numberOfSugar;

    public Image[] lives;
    public Sprite fullSugar;
    public Sprite emptySugar;


    private void Start()
    {
       
        currentHealth = health;
        health = 3;
    }

    void Update()
    {


        if(health> numberOfSugar)
        {
            health = numberOfSugar;
        }

        for(int i = 0; i < lives.Length; i++)
        {
            if(i < health)
            {
                lives[i].sprite = fullSugar;

            }
            else
            {
                lives[i].sprite = emptySugar;
            }
            if(i < numberOfSugar)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }

        
        if (health < 1)
        {
            LoseGame();
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
           
            health -= 1;
            
        }
        if(col.tag == "killzone")
        {
            health -= 1;
        }
    }

 

    public void LoseGame()
        {
            SceneManager.LoadScene("GameOverScene");
        }

    } 


