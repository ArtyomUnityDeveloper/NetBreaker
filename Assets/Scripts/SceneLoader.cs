using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadLvl4()
    {
        SceneManager.LoadScene(4);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadLvl5()
    {
        SceneManager.LoadScene(5);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadLvl6()
    {
        SceneManager.LoadScene(6);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadLvl7()
    {
        SceneManager.LoadScene(7);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadLvl8()
    {
        SceneManager.LoadScene(8);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadLvl9()
    {
        SceneManager.LoadScene(9);
        FindObjectOfType<GameSession>().ResetGame();
    }
}
