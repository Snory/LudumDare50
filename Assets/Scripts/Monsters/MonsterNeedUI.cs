using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterNeedUI : MonoBehaviour
{
    public Image Timer;
    public GameObject NeedObjectParent;
    public Image NeedImage;

    [SerializeField]
    private Sprite NeedPhase, SellPhase;


    public void OnTimerTick(float MaxTime, float currentTime)
    {
        float timerValue =  1 - (currentTime / MaxTime);
        Timer.fillAmount = timerValue;
    }

    public void OnCurrentNeedChanged(Need n)
    {
        NeedObjectParent.SetActive(true);
        Timer.sprite = NeedPhase;
        NeedImage.sprite = n.NeedSprite;
    }

    public void OnSatisfied()
    {
        NeedObjectParent.SetActive(false);
        Timer.sprite = SellPhase;

    }

    public void OnSelected()
    {

    }


}
