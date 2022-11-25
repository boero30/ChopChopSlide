using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
    }

    public void Level5()
    {
        SceneManager.LoadScene(5);
    }
    public void Ajustes()
    {
        SceneManager.LoadScene(6);
    }
    public void Ayuda()
    {
        SceneManager.LoadScene(7);
    }
    public void Credits()
    {
        SceneManager.LoadScene(8);

    }
    public void Death()
    {
        SceneManager.LoadScene(9);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(10);
    }
    public void Lose()
    {
        SceneManager.LoadScene(11);
    }
    public void Win()
    {
        SceneManager.LoadScene(12);
    }
}
