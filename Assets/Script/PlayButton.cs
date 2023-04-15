using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private float delay = 4f;
    private float delayAdd = 0f;
    

    
    public void LevelScene()
    {
        SceneManager.LoadScene("Level");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter(Collider other)
    {
        delayAdd += Time.deltaTime;
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
