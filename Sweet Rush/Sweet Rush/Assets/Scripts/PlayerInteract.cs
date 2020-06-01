﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UIElements;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObject = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    
    private Exit exit;

    // Update is called once per frame
    void Update()
    {

        if (CrossPlatformInputManager.GetButtonDown("PickUp") && currentInterObject)
        {
            
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObject);
            }
            if (currentInterObjScript.openable)
            {

                if (currentInterObjScript.locked)
                {
                    if (inventory.FindItem(currentInterObjScript.itemNeeded)) 
                    {
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObject.name + " was unlocked");
                    }
                    else
                    {
                        Debug.Log(currentInterObject.name + " was not unlocked");
                    }

                }
                else if (currentInterObjScript.openable)
                {

                    
                 
                    Debug.Log(currentInterObject.name + " is unlocked");
                    currentInterObjScript.Open();
                    Invoke("WinGame", 4f);
                }
            }
            
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObject = other.gameObject;
            currentInterObjScript = currentInterObject.GetComponent<InteractionObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObject)
            {
                currentInterObject = null;
            }
        }
    }

    void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

}
