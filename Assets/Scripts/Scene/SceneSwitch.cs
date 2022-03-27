using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public string CurrentScene;
    public string NextScene;
    public BoolVariable Additive;

    [SerializeField]
    private SceneTransitionBase _sceneTransition;

    public void SwitchScene()
    {
        _sceneTransition.TransitToScene(CurrentScene, NextScene, Additive.Value);
    }
}
