using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    private readonly string _blackScreenAssetName = "BlackScreenUI";

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
    public  void MappingAdditive()
    {
        SceneManager.LoadScene("MappingAdditive", LoadSceneMode.Additive);
        GameManager.mappingAbierto = true;
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
        Time.timeScale = 0;

        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        GameManager.gameOver = false;

    }
    public void GameOverDetry()
    {
        SceneManager.UnloadSceneAsync("GameOver");
    }
    public void Salir(float _delaySeconds)
    {
        StartCoroutine(ExitRoutine(_delaySeconds));
    }

    private IEnumerator ExitRoutine(float _delaySeconds)
    {
        Transform canvasTransform = GameObject.FindObjectOfType<Canvas>().transform;
        Instantiate(Resources.Load(_blackScreenAssetName), canvasTransform);
        yield return new WaitForSeconds(_delaySeconds);
        Application.Quit();
    }

}//end Class
