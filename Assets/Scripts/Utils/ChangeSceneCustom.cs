using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneCustom : MonoBehaviour
{
    [SerializeField, Range(0f, 5f)]
    private float _delaySeconds = 0f;
    [SerializeField]
    private string _sceneName = "MainMenu";
    [SerializeField]
    private bool _createBlackScreenWhileWaiting = false;

    private readonly string _blackScreenAssetName = "BlackScreenUI";

    public void ChangeSceneWithDelay()
    {
        StartCoroutine(ChangeSceneRoutine());
    }

    private IEnumerator ChangeSceneRoutine()
    {
        if(_createBlackScreenWhileWaiting)
            ActivateBlackScreen();
        yield return new WaitForSeconds(_delaySeconds);
        SceneManager.LoadScene(_sceneName);
    }

    private void ActivateBlackScreen()
    {
        Transform canvasTransform = GameObject.FindObjectOfType<Canvas>().transform;
        Instantiate(Resources.Load(_blackScreenAssetName), canvasTransform);
    }
}
