using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObject = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;

    private string pickUp;
    private Exit exit;

    // Update is called once per frame
    void Update()
    {
  
    if (pickUp == "pickUp" && currentInterObject)
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
                    Invoke("WinGame", 3.5f);
                }
            }
            
        }
        
    }

    public void PickUp()
    {
        pickUp = "pickUp";
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
