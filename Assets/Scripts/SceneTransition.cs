using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private string _currentScene;

    public void TransitToScene(string newSceneName, LoadSceneMode loadMode)
    {
        if (!string.IsNullOrEmpty(_currentScene))
        {
            AsyncOperation asyncUnLoad = SceneManager.UnloadSceneAsync(_currentScene);
            if (asyncUnLoad == null)
            {
                throw new Exception("Unable to unload current scene");
            }
            asyncUnLoad.completed += OnSceneUnloaded;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newSceneName, loadMode);
        if (asyncLoad == null)
        {
            throw new Exception("Unable to load new scene");
        }
        asyncLoad.completed += OnSceneLoaded;
        _currentScene = newSceneName;
    }


    private void OnSceneUnloaded(AsyncOperation obj)
    {
        Debug.Log("Scene unloaded");
    }

    private void OnSceneLoaded(AsyncOperation obj)
    {
        Debug.Log("Scene loaded");

    }
}
