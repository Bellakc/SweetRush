using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
 

	public static GameController gameControllerInstance;
    public GameObject exit;


	private Quaternion originalCameraRotation;

	[HideInInspector]
	public int candy;
	public int levelToLoad;



	void Start()
	{
		gameControllerInstance = this;
		candy = 0;
		originalCameraRotation = Camera.main.transform.rotation;
    }


	void Update()
	{
		exit.GetComponent<Exit>().amountOfCandy = candy;

       
	}


    public void ScreenShake()
    {
        Camera.main.DOShakeRotation(0.2f, 4, 20, 70);

        Invoke("ResetCameraRotation", 0.2f);
    }

    private void ResetCameraRotation()
    {
        Camera.main.transform.rotation = originalCameraRotation;
    }

    //public void Restart()
    //{
    //    GameObject pacMan = GameObject.Find("Girl");
    //    pacMan.transform.GetComponent<PacmanMove>().Respawn();
    //}

    public void LoadLevel(int levelToLoad)
	{
		int previousCandy = PlayerPrefs.GetInt("candy");
		previousCandy += candy;
		PlayerPrefs.SetInt("candy", previousCandy);
		SceneManager.LoadScene(levelToLoad);
	}


}