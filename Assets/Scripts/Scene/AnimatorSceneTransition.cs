using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;





public class AnimatorSceneTransition : SceneTransitionBase
{
    [SerializeField]
    private Animator _sceneTransitionAnimator;
    
    [SerializeField]
    private float _initTransitionDelay;

    [SerializeField]
    private float _initLoadDelay = 1.5f;

    public override void TransitToScene(string currentSceneName, string newSceneName, bool additive)
    {
        StartCoroutine(RunAnimator(currentSceneName,newSceneName, additive));
    }

    public IEnumerator RunAnimator(string currentSceneName, string newSceneName, bool additive)
    {
        yield return new WaitForSeconds(_initTransitionDelay);
        _sceneTransitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(_initLoadDelay);
        LoadScene(newSceneName,additive);
        if (additive)
        {
            UnloadScene(currentSceneName);
        }

    }
}

