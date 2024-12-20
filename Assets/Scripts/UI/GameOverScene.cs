using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public string gameSceneName = "GameScene";
    public void RestartGame()
    {

        // Restart the game
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();


    }
}


