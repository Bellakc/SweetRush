using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public AudioSource myAudioSource;


    private float musicVolume = 1f;

    public void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        myAudioSource.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
        
    }

    public void LoadLevel(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
