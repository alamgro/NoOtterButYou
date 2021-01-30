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
    public static void Pause()
    {
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
       // SceneManager.UnloadSceneAsync("MappingAdditive");
    }
    public static void PauseDestry()
    {
        SceneManager.UnloadSceneAsync("Pause");
    }
    public void Salir()
    {
        Application.Quit();
    }

    
}
