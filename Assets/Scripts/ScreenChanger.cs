using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScreenChanger : MonoBehaviour
{

    public void StarterSceneSwitch()
    {
        SceneManager.LoadScene("Choose Level Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOverHomeScene()
    {
        SceneManager.LoadScene("Starter Screen");
    }

    public void GameOverLevelScene()
    {
        SceneManager.LoadScene("Choose Level Screen");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }
}
