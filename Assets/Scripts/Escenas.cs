using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Escenas : MonoBehaviour
{
    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void MappingScene()
    {
        SceneManager.LoadScene("Mapping");
    }
    public void Juego()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MappingAdditive()
    {
        SceneManager.LoadScene("MappingAdditive", LoadSceneMode.Additive);
    }
    public void MappingAdditiveDestroy()
    {
        SceneManager.UnloadSceneAsync("MappingAdditive");
    }
    public static void Pause()
    {
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }
    public static void PauseDestroy()
    {
        SceneManager.UnloadSceneAsync("Pause");
        Time.timeScale = 1;


    }
    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
    }
    public void GameOverDetry()
    {
        SceneManager.UnloadSceneAsync("GameOver");
    }
    public void Salir()
    {
        Application.Quit();
    }

}//end Class
