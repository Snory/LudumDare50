using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Market : MonoBehaviour
{
    public List<Satisfier> StartMarketSatisfiers;

    [SerializeField]
    private SatisfierEvent _buySatisfier;

    public UnityEvent<Market> MarketPrepared;

    [SerializeField]
    private Score _score;

    private void Start()
    {
        RaiseMarketPrepared();
    }

    public void RaiseMarketPrepared()
    {
        if(MarketPrepared != null)
        {
            MarketPrepared.Invoke(this);
        }
    }

    //nooo singletooo, nooo
    public void OnRequestToBuySatisfier(Satisfier s)
    {
        if(_score.ScoreValue >= s.SatisfierPrice)
        {
            _score.OnScoreRequestUpdate(-1* s.SatisfierPrice);
            RaiseBuySatisfier(s);
        }
    }

    public void RaiseBuySatisfier(Satisfier s)
    {
        if(_buySatisfier != null)
        {
            _buySatisfier.Raise(s);
        }
    }
}
