using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneTransitionBase : MonoBehaviour
{
    protected string _currentScene;

    public abstract void UnloadCurrentScene();
    public abstract void LoadScene(string newSceneName, LoadSceneMode loadMode);

    public virtual void TransitToScene(string newSceneName, LoadSceneMode loadMode)
    {
        UnloadCurrentScene();
        LoadScene(newSceneName, loadMode);
    }
    public virtual void ReloadCurrentScene()
    {
        UnloadCurrentScene();
        LoadScene(_currentScene, LoadSceneMode.Additive);
    }
}
