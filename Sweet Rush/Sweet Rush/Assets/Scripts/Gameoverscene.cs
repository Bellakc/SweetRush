using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameoverscene : MonoBehaviour
{

    void Start()
    {
        Invoke("GameOverScene", 3f);

    }


    void GameOverScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
