using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 spawnPoint;

  
  
    public void SpawnEnemy()
    {

        //yield return new WaitForSeconds(4f);
  
            Instantiate(enemy, spawnPoint, Quaternion.identity);

    }
   
}
