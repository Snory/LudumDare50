using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;





public class SceneTransition : SceneTransitionBase
{
       

    public override void LoadScene(string newSceneName, LoadSceneMode loadMode)
    {
        StartCoroutine(LoadSceneRoutine(newSceneName, loadMode));
    }

    private IEnumerator LoadSceneRoutine(string newSceneName, LoadSceneMode loadMode)
    {

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(newSceneName, loadMode);
        asyncOp.allowSceneActivation = false;

        while (!asyncOp.isDone)
        {
            if (asyncOp.progress >= 0.9f)
            {
                asyncOp.allowSceneActivation = true;
                _currentScene = newSceneName;

            }

            yield return null;
        }

        yield return null;



    }

    public override void UnloadCurrentScene()
    {
        if (!string.IsNullOrEmpty(_currentScene))
        {
            StartCoroutine(UnloadCurrentSceneRoutine());
        }
    }

    private IEnumerator UnloadCurrentSceneRoutine()
    {
        AsyncOperation asyncOp = SceneManager.UnloadSceneAsync(_currentScene);
        asyncOp.allowSceneActivation = false;

        while (!asyncOp.isDone)
        {
            if (asyncOp.progress >= 0.9f)
            {
                asyncOp.allowSceneActivation = true;                
            }

            yield return null;
        }
        yield return null;
    }

}
