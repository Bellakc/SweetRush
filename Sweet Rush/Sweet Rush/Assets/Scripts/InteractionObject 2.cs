using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;
    public bool openable;
    public bool locked;

    public GameObject itemNeeded;
  
    public Animator anim;
    

    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }
 
}
