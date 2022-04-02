using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class MonsterNeedSatisfier
{
    public Need Need { get;}
    public Satisfier Satisfier;


    public MonsterNeedSatisfier(Need n, Satisfier defaultSatisfier)
    {
        this.Need = n;
        this.Satisfier = defaultSatisfier;
    }
}
