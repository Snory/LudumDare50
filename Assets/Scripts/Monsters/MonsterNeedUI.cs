using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterNeedUI : MonoBehaviour
{

    [SerializeField]
    private MonsterNeedsCycleType _needCycleType, _evaluationCycleType, _sellCycleType;

    public Image Timer;
    public GameObject NeedObjectParent;
    public Image NeedImage;

    [SerializeField]
    private Sprite _needPhase, _sellPhase, _evaluationPhase;

    private Animator _monsterNeedUIAnimator;

    private Need _needToShow;

    
    private void Awake()
    {
        this.GetComponent<Canvas>().worldCamera = Camera.main;

        _monsterNeedUIAnimator = this.GetComponent<Animator>();
    }
    public void OnTimerTick(float MaxTime, float currentTime)
    {
        float timerValue =  1 - (currentTime / MaxTime);
        Timer.fillAmount = timerValue;
    }


    public void OnInncerCycleChanged(MonsterNeedsCycleType cycleTYpe)
    {

        if (cycleTYpe == _needCycleType)
        {
            OnNeedCycle();

        }
        else if (cycleTYpe == _sellCycleType)
        {
            OnSellCycle();
        } else if (cycleTYpe == _evaluationCycleType)
        {
            OnEvaluationCycle();
        }
    }

    private void OnNeedCycle()
    {
        if (NeedObjectParent.activeSelf)
        {
            BubbleDown(false);
        } else
        {
            BubbleUp();
        }

        Timer.sprite = _needPhase;
    }

    private void BubbleUp()
    {
        _monsterNeedUIAnimator.SetTrigger("BubbleUp");
    }

    private void ShowNeed()
    {
        NeedImage.sprite = _needToShow.NeedSprite;
    }

    private void BubbleDown(bool fast)
    {
        if (!fast)
        {
            _monsterNeedUIAnimator.SetTrigger("BubbleDown");
        } else
        {
            _monsterNeedUIAnimator.SetTrigger("BubbleDownFast");
        }
    }

    private void OnSellCycle()
    {
        Timer.sprite = _sellPhase;
    }

    private void OnEvaluationCycle()
    {
        BubbleDown(true);
        Timer.sprite = _evaluationPhase;
    }

    public void OnCurrentNeedChanged(Need n)
    {
        OnNeedCycle();
        _needToShow = n;
    }


    public void OnSatisfied()
    {
        OnEvaluationCycle();
    }


}
