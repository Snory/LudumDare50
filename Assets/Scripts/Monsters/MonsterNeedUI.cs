using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterNeedUI : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public GameObject NeedObject;


    public void OnTimerTick(float MaxTime, float currentTime)
    {
        Text.text = (MaxTime - currentTime).ToString();
    }

    public void OnCurrentNeedChanged(Need n)
    {
        NeedObject.SetActive(true);
        NeedObject.GetComponent<Image>().sprite = n.NeedSprite;
    }

    public void OnSatisfied()
    {
        NeedObject.SetActive(false);
    }


}
