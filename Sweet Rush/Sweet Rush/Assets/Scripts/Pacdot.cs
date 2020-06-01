using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Player")
        {
            Destroy(gameObject);

            GameController.gameControllerInstance.candy++;
        }
    }
}
