using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


[CreateAssetMenu(fileName = "NewFoodNeed", menuName = "Need/GeneralNeed", order = 1)]
public class Need : ScriptableObject
{
    public List<Satisfier> PossibleSatisfiers;
    public Sprite NeedSprite;

    public float NeedScorePenalty = 50;
    public float NeedScoreGain = 100;


    public virtual bool CanUseSatisfier(Satisfier s)
    {
        bool canUse = PossibleSatisfiers.Contains(s);
        return canUse;
    }
       
}
