using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewFoodNeed", menuName = "Need/FoodNeed", order = 1)]
public class FoodNeed : Need
{
    public override bool SatisfyNeed()
    {
        Debug.Log("Food satisfaction");

        return false;
    }
}
