using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Level");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}