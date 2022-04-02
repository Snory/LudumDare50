using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class NeedProbability 
{
    public Need Need;

    [Range(0,100)]
    public int Probability;
}
