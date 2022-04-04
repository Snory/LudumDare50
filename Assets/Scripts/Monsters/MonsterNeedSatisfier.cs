using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class MonsterNeedSatisfier
{
    public Need Need { get;}
    public Satisfier Satisfier;
    public Satisfier DefaultSatisfier;


    public MonsterNeedSatisfier(Need n, Satisfier assignedSatisfier, Satisfier DefaultSatisfier)
    {
        this.Need = n;
        this.Satisfier = assignedSatisfier;
        this.DefaultSatisfier = DefaultSatisfier;
    }

    public bool IsDefaultSatisfierUsed()
    {
        return Satisfier == DefaultSatisfier;
    }
}
