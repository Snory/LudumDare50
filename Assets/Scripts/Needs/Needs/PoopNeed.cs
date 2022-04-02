using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PoopNeed", menuName = "Need/PoopNeed", order = 1)]
public class PoopNeed : Need
{
    public override bool SatisfyNeed()
    {
        Debug.Log("Poop satisfaction");

        return false;
    }
}