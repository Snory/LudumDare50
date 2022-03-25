using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneTransitionBase : MonoBehaviour
{
    public abstract void UnloadCurrentScene();
    public abstract void LoadScene(string newSceneName, LoadSceneMode loadMode);

    public virtual void TransitToScene(string newSceneName, LoadSceneMode loadMode)
    {
        UnloadCurrentScene();
        LoadScene(newSceneName, loadMode);
    }
}
