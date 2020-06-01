using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[10];
    
    
    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
               
                GameObject.Find("key").transform.localScale = new Vector3(0, 0, 0);
                itemAdded = true;
                
                item.SendMessage("DoInteraction");
                
                break;

            }
        }

        if (!itemAdded)
        {
            Debug.Log("Inventory Full - Item Not Added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == item)
            {
                return true;
            }
        }
        return false;
    }
   }
