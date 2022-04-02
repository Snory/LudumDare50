using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewNeedCategory", menuName = "Need/NeedCategory", order = 2)]
public class NeedCategory : ScriptableObject
{
    public List<NeedProbability> NeedProbabilities;
    public Satisfier DefaultSatisfier;

    //return need from needprobabilities

    public Need GetNeed()
    {
        int randomNumber = UnityEngine.Random.Range(0, 101);
        int currentMax = 0;

        for (int i = 0; i < NeedProbabilities.Count; i++)
        {
            if(randomNumber >= currentMax && randomNumber <= currentMax + NeedProbabilities[i].Probability)
            {
                return NeedProbabilities[i].Need;
            } else
            {
                currentMax += NeedProbabilities[i].Probability;
            }
        }

        return null;
    }

}
