using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneSwitch : MonoBehaviour
{
    public string CurrentScene;
    public string NextScene;
    public BoolVariable Additive;


    [SerializeField]
    private EventSystem _eventSystemInScene;

    [SerializeField]
    private AudioListener _audioListenerInScene;

    [SerializeField]
    private SceneTransitionBase _sceneTransition;

    public void SwitchScene()
    {
        if(_eventSystemInScene != null)
        {
            _eventSystemInScene.enabled = false;
        }

        if (_audioListenerInScene != null)
        {
            _audioListenerInScene.enabled = false;
        }

        _sceneTransition.TransitToScene(CurrentScene, NextScene, Additive.Value);
    }
}
