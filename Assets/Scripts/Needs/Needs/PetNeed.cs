using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PetNeeed", menuName = "Need/PetNeed", order = 1)]
public class PetNeed : Need
{
    public override bool SatisfyNeed()
    {
        Debug.Log("Pet satisfaction");

        return true;
    }
}
