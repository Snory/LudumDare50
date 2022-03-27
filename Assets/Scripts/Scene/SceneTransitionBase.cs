
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;




public abstract class SceneTransitionBase : MonoBehaviour
{
    
    [SerializeField]
    private GlobalEvent _sceneLoaded;

    public void UnloadScene(string currentSceneName)
    {
        if(SceneManager.sceneCount == 1)
        {
            return;
        }
        StartCoroutine(UnloadSceneRoutine(currentSceneName));
    }

    public void LoadScene(string newSceneName, bool additive)
    {
        StartCoroutine(LoadSceneRoutine(newSceneName, additive));
    }
        
    private IEnumerator LoadSceneRoutine(string newSceneName,bool additive)
    {
        LoadSceneMode mode = additive == true ? LoadSceneMode.Additive : LoadSceneMode.Single;

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(newSceneName, mode);
        asyncOp.allowSceneActivation = false;

        while (!asyncOp.isDone)
        {
            if (asyncOp.progress >= 0.9f)
            {
                asyncOp.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    private IEnumerator UnloadSceneRoutine(string currentSceneName)
    {
        AsyncOperation asyncOp = SceneManager.UnloadSceneAsync(currentSceneName);
        //run hide anim
        while (!asyncOp.isDone)
        {
            yield return null;
        }
    }

    public virtual void TransitToScene(string currentSceneName, string newSceneName, bool additive)
    {
        UnloadScene(currentSceneName);
        LoadScene(newSceneName, additive);
    }

    public void SceneLoaded()
    {
        _sceneLoaded.Raise();
    }
}
