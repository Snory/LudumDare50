using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneSwitch : MonoBehaviour
{
    public string CurrentScene;
    public string NextScene;
    public BoolVariable Additive;

    public EventSystem EventSystemInScene;

    [SerializeField]
    private SceneTransitionBase _sceneTransition;

    public void SwitchScene()
    {
        if(EventSystemInScene != null)
        {
            EventSystemInScene.enabled = false;
        }
        _sceneTransition.TransitToScene(CurrentScene, NextScene, Additive.Value);
    }
}
