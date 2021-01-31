using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EscenasAdditive : MonoBehaviour
{
   
    public void PauseDestry()
    {
        Time.timeScale = 1;

        SceneManager.UnloadSceneAsync("Pause");
        GameManager.pause = !GameManager.pause;


    }
    /*public  void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        GameManager.gameOver = false;
    }*/
    public static void MappingAdditiveDestroy()
    {
        SceneManager.UnloadSceneAsync("MappingAdditive");
    }
}
