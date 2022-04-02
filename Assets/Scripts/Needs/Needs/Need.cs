using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;



public abstract class Need : ScriptableObject
{
    public List<Satisfier> PossibleSatisfiers;
    public virtual bool SatisfyNeed(Satisfier s)
    {
        bool satisfied = PossibleSatisfiers.Contains(s);
        return satisfied;
    }
       
}
