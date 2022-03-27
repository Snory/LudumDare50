using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;





public class AnimatorSceneTransition : SceneTransitionBase
{
    [SerializeField]
    private Animator _sceneTransitionAnimator;

    public override void TransitToScene(string currentSceneName, string newSceneName, bool additive)
    {
        StartCoroutine(RunAnimator(currentSceneName,newSceneName, additive));
    }

    public IEnumerator RunAnimator(string currentSceneName, string newSceneName, bool additive)
    {
        _sceneTransitionAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.5f);
        LoadScene(newSceneName,additive);
        if (additive)
        {
            UnloadScene(currentSceneName);
        }

    }
}

