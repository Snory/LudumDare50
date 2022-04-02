using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatisfierStockElementUI : MonoBehaviour
{

    [SerializeField]
    private SatisfierEvent _requestToUseSatisfier;

    private Satisfier _satisfier;
    public Satisfier Satisfier { get => _satisfier; set => _satisfier = value; }

    public void RaiseRequestToUseSatisfier()
    {
        if (_requestToUseSatisfier != null)
        {
            _requestToUseSatisfier.Raise(_satisfier);
        }
    }


}
