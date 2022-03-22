using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneTransitionBase : MonoBehaviour
{
    public abstract void TransitToScene(string newSceneName, LoadSceneMode loadMode);
}
